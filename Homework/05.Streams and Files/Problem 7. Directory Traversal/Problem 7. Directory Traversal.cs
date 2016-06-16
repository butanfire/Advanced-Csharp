namespace Problem_7.Directory_Traversal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    public class DirectoryTraversal
    {
        const string reportFile = @"\report.txt";

        public static void Main(string[] args)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string outputFile = path + reportFile;

            string directoryName = Console.ReadLine();

            var fileInfoList = TraverseDirectory(directoryName);

            var groupedFiles = from files in fileInfoList
                               group files by files.Extension into newGroup
                               select newGroup;

            using (var writer = new StreamWriter(outputFile))
            {
                foreach (var group in groupedFiles)
                {
                    writer.WriteLine(group.Key + ": ");
                    foreach (var file in group.OrderBy(s => s.Length))
                    {
                        writer.WriteLine("--" + file.Name + " - " + file.Length + "kb");
                    }
                }
            }
        }

        public static List<FileInfo> TraverseDirectory(string directoryName)
        {
            var fileNames = Directory.GetFiles(directoryName);
            return fileNames.Select(file => new FileInfo(file)).ToList();
        }
    }
}

