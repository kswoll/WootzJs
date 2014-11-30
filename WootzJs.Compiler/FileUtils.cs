using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace WootzJs.Compiler
{
    public static class FileUtils
    {
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
                if (wootzJs.StartsWith(".."))
                {
                    var projectFolderInfo = new DirectoryInfo(projectFile);
                    while (wootzJs.StartsWith(".."))
                    {
                        wootzJs = wootzJs.Substring(@"..\".Length);
                        projectFolderInfo = projectFolderInfo.Parent;
                    }
                    wootzJs = projectFolderInfo.FullName + "\\" + wootzJs;
                }
                var currentFolder = new FileInfo(wootzJs).Directory;
                while (currentFolder != null)
                {
                    if (currentFolder.Name == "WootzJs")
                        break;
                    currentFolder = currentFolder.Parent;
                }
                if (currentFolder != null)
                {
                    return currentFolder.FullName + @"\WootzJs.Runtime\WootzJs.Runtime.csproj";
                }
            }
            return null;
        }
    }
}