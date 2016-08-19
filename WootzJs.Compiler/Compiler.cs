#region License
//-----------------------------------------------------------------------
// <copyright>
// The MIT License (MIT)
// 
// Copyright (c) 2014 Kirk S Woll
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
//-----------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using Nito.AsyncEx;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class Compiler
    {
        public static bool RemoveUnusedSymbols;

        private string mscorlib;
        private string[] defines;

        public Compiler(string mscorlib, string[] defines)
        {
            this.mscorlib = mscorlib;
            this.defines = defines;
        }

        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide two arguments:");
                Console.WriteLine("1. The fully qualified path to your .csproj file.");
                Console.WriteLine("2. The relative path to your project's output folder.");
                Console.WriteLine();
                Console.WriteLine("For example:");
                Console.WriteLine(@"WootzJs.Compiler.exe c:\dev\MyProject\MyProject.csproj bin\");
                return;
            }
            var projectOrSolutionFile = args[0];
            var outputFolder = args[1];
            var namedArguments = args.Skip(2).Select(x => x.Split('=')).ToDictionary(x => x[0], x => x[1]);
            var mscorlib = namedArguments.Get("mscorlib");
            var performanceFile = namedArguments.Get("performanceFile");
            var define = namedArguments.Get("define");
            var defines = define == null ? new string[0] : define.Split(',');

            if (performanceFile != null)
            {
                Profiler.Output = new StreamWriter(performanceFile);
            }

            var fileInfo = new FileInfo(projectOrSolutionFile);
            var fileFolder = fileInfo.Directory.FullName;
            AsyncContext.Run(async () =>
            {
                try
                {
                    if (fileInfo.Extension.Equals(".sln", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var result = await Profiler.Time("Total Time", async () => await new Compiler(mscorlib, defines).CompileSolution(projectOrSolutionFile));                    
                        var output = result.Item1;
                        var solution = result.Item2;
                        var solutionName = fileInfo.Name.Substring(0, fileInfo.Name.Length - ".sln".Length);
                        File.WriteAllText(fileFolder + "\\" + outputFolder + solutionName + ".js", output);
                    }
                    else
                    {
                        var result = await Profiler.Time("Total Time", async () => await new Compiler(mscorlib, defines).CompileProject(projectOrSolutionFile));
                        var output = result.Item1;
                        var project = result.Item2;
                        var projectName = project.AssemblyName;

                        File.WriteAllText(fileFolder + "\\" + outputFolder + projectName + ".js", output);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"MSBUILD : error : WootzJs: {e.Message}");
                    Console.WriteLine(e);
                    Console.ReadLine();
                    Environment.Exit(1);
                }
            });
        }

        public async Task<Tuple<string, Solution>> CompileSolution(string solutionFile)
        {
//            var solution = await Profiler.Time("Loading Project", async () => await MSBuildWorkspace.Create().OpenSolutionAsync(solutionFile));
            var jsCompilationUnit = new JsCompilationUnit { UseStrict = true };

            // Since we have all the types required by the solution, we can keep track of which symbols are used and which
            // are not.  This of course means depending on reflection where you don't reference the actual symbol in code
            // will result in unexpected behavior.
            RemoveUnusedSymbols = true;

            var projectFiles = FileUtils.GetProjectFiles(solutionFile);
            var workspace = MSBuildWorkspace.Create();
            var solution = await Profiler.Time("Loading Solution", async () =>
            {
                string mscorlib = this.mscorlib;
                if (mscorlib == null)
                {
                    mscorlib = projectFiles.Select(x => FileUtils.GetWootzJsTargetFile(x)).First();
                }
                Solution result = workspace.CurrentSolution;
                if (mscorlib != null)
                {
                    var mscorlibProject = await workspace.OpenProjectAsync(mscorlib);
//                    result = result.AddProject(mscorlibProject.Id, mscorlibProject.Name, mscorlibProject.AssemblyName, mscorlibProject.Language);
                    foreach (var projectFile in projectFiles)
                    {
                        var project = result.Projects.SingleOrDefault(x => x.FilePath.Equals(projectFile, StringComparison.InvariantCultureIgnoreCase));
                        if (project == null)
                            project = await workspace.OpenProjectAsync(projectFile);
//                        result = result.AddProject(project.Id, project.Name, project.AssemblyName, project.Language);
//                        project = result.GetProject(project.Id);
                        project = project.AddProjectReference(new ProjectReference(mscorlibProject.Id));
                        project = project.RemoveMetadataReference(project.MetadataReferences.Single(x => x.Display.Contains("mscorlib.dll")));                        
                        result = project.Solution;
                    }
                }
                else
                {
                    result = await workspace.OpenSolutionAsync(solutionFile);
                }
                return result;
            });

            var projectCompilers = SortProjectsByDependencies(solution).Select(x => new ProjectCompiler(x, jsCompilationUnit, defines)).ToArray();
            foreach (var compiler in projectCompilers)
            {
                await compiler.Compile();
            }

            // Write out the compiled Javascript file to the target location.
            var renderer = new JsRenderer();
            Profiler.Time("Rendering javascript", () => jsCompilationUnit.Accept(renderer));

//            solution.Projects
            return Tuple.Create(renderer.Output, solution);
        }

        private IEnumerable<Project> SortProjectsByDependencies(Solution solution)
        {
            var projects = solution.Projects.Select((x, i) => new { Index = i, Project = x }).ToList();
            var prepend = projects.Take(0).ToHashSet();
            do
            {
                if (prepend.Any())
                    projects = prepend.Concat(projects.Except(prepend)).Select((x, i) => new { Index = i, x.Project }).ToList();
                prepend.Clear();
                var mscorlib = projects.Single(x => x.Project.AssemblyName == "mscorlib");
                foreach (var item in projects)
                {
                    var referencedProjects = item.Project.ProjectReferences.Where(x => solution.ProjectIds.Contains(x.ProjectId)).Select(x => projects.Single(y => y.Project.Id == x.ProjectId)).ToList();
                    if (item.Project.Id != mscorlib.Project.Id)
                        referencedProjects.Add(mscorlib);
                    foreach (var referencedProject in referencedProjects)
                    {
                        if (referencedProject.Index > item.Index)
                        {
                            prepend.Add(referencedProject);
                        }
                    }
                }
            } while (prepend.Any());

            return projects.Select(x => x.Project).ToArray();
        }

        public async Task<Tuple<string, Project>> CompileProject(string projectFile)
        {
            var projectFileInfo = new FileInfo(projectFile);
            var projectFolder = projectFileInfo.Directory.FullName;

            // These two lines are just a weird hack because you get no files back from compilation.SyntaxTrees
            // if the user file isn't modified.  Not sure why that's happening.
//            var projectUserFile = projectFolder + "\\" + projectFileInfo.Name + ".user";
//            if (File.Exists(projectUserFile))
//                File.SetLastWriteTime(projectUserFile, DateTime.Now);

            var jsCompilationUnit = new JsCompilationUnit { UseStrict = true };
            var workspace = MSBuildWorkspace.Create();
            var project = await Profiler.Time("Loading Project", async () =>
            {
                string mscorlib = this.mscorlib;
                if (mscorlib == null)
                {
                    mscorlib = FileUtils.GetWootzJsTargetFile(projectFile);
                }
                Project result;
                if (mscorlib != null)
                {
                    var mscorlibProject = await workspace.OpenProjectAsync(mscorlib);
                    result = await workspace.OpenProjectAsync(projectFile);
					if (!result.ProjectReferences.Any(projectReference => projectReference.ProjectId == mscorlibProject.Id)) {
						result = result.AddProjectReference(new ProjectReference(mscorlibProject.Id));
					}

					MetadataReference metadataReference = result.MetadataReferences.SingleOrDefault(x => x.Display.Contains("mscorlib.dll"));
					if (metadataReference != null) {
						result = result.RemoveMetadataReference(metadataReference);
					}
                }
                else
                {
                    result = await workspace.OpenProjectAsync(projectFile);
                }

                return result;
            });
            var projectCompiler = new ProjectCompiler(project, jsCompilationUnit, defines);
            await projectCompiler.Compile();

            // Write out the compiled Javascript file to the target location.
            var renderer = new JsRenderer();
//            renderer.Builder.IsCompacting = true;
            Profiler.Time("Rendering javascript", () => jsCompilationUnit.Accept(renderer));

            return Tuple.Create(renderer.Output, project);
        }
    }
}
