using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace WootzJs.Compiler
{
    public static class FileUtils
    {
        public static string[] GetProjectFiles(string solutionFile)
        {
            var projectFiles = new List<string>();
            using (var reader = new StreamReader(solutionFile))
            {
                for (var line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    if (line.StartsWith("Project("))
                    {
                        var nameValue = line.Split(new[] { " = " }, StringSplitOptions.None);
                        var parts = nameValue[1].Split(new[] { ", " }, StringSplitOptions.None);
                        var projectFile = parts[1];
                        projectFile = projectFile.Substring(1, projectFile.Length - 2);
                        projectFile = ResolveRelativePath(solutionFile, projectFile);
                        projectFiles.Add(projectFile);
                    }
                }
            }
            return projectFiles.ToArray();
        }

        public static string GetWootzJsTargetFile(string projectFile)
        {
            var projectXml = XDocument.Load(new StreamReader(projectFile));
            var wootzJs = projectXml.Root.Elements()
                .Where(x => x.Name.LocalName == "Import")
                .SelectMany(x => x.Attributes())
                .Where(x => x.Name.LocalName == "Project" && x.Value.EndsWith("WootzJs.targets"))
                .Select(x => x.Value)
                .SingleOrDefault();
            if (wootzJs != null)
            {
                wootzJs = ResolveRelativePath(projectFile, wootzJs);
                var currentFolder = new FileInfo(wootzJs).Directory;
                while (currentFolder != null)
                {
                    // 2015-10-19 - Mark Stega - Removed dependency on the build directory for the targets file
                    //              Why was this here?
                    if (File.Exists(Path.Combine(currentFolder.FullName, @"WootzJs.targets")))
                        break;
//                    if (currentFolder.Name.Equals("WootzJs", StringComparison.InvariantCultureIgnoreCase))
//                        break;
                    currentFolder = currentFolder.Parent;
                }
                if (currentFolder != null)
                {
                    return currentFolder.FullName + @"\WootzJs.Runtime\WootzJs.Runtime.csproj";
                }
            }
            return null;
        }

        public static string ResolveRelativePath(string currentPath, string newPath)
        {
            if (Path.IsPathRooted(newPath))
                return newPath;
            var projectFolderInfo = new DirectoryInfo(currentPath);
            if (!projectFolderInfo.Exists)
                projectFolderInfo = projectFolderInfo.Parent;
            while (newPath.StartsWith(".."))
            {
                newPath = newPath.Substring(@"..\".Length);
                projectFolderInfo = projectFolderInfo.Parent;
            }
            newPath = projectFolderInfo.FullName + "\\" + newPath;
            return newPath;
        }
    }
}