namespace Problem_8.Full_Directory_Traversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FullDirectoryTraversal
    {
        private const string ReportFile = @"\report.txt";
        private static readonly string OutputFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + ReportFile;
        public static List<FileInfo> FileInfoList = new List<FileInfo>();

        public static void TraverseDirectory(string directoryName)
        {
            var directories = Directory.GetDirectories(directoryName);
            var fileNames = Directory.GetFiles(directoryName).ToList();

            foreach (var item in fileNames.Select(file => new FileInfo(file)))
            {
                FileInfoList.Add(item);
            }

            var subDirs = Directory.GetDirectories(directoryName);
            foreach (var subdir in subDirs)
            {
                TraverseDirectory(subdir);
            }
        }

        public static void Main(string[] args)
        {
            string directoryName = Console.ReadLine();

            TraverseDirectory(directoryName);

            var groupedFiles =
                FileInfoList.OrderByDescending(files => files.Length)
                    .GroupBy(files => files.Extension)
                    .Select(extensionGroup => extensionGroup);

            using (var writer = new StreamWriter(OutputFile))
            {
                foreach (var group in groupedFiles)
                {
                    writer.WriteLine(group.Key + ": ");
                    foreach (var file in group)
                    {
                        writer.WriteLine("--" + file.Name + " - " + file.Length + "kb");
                    }

                    writer.WriteLine();
                }
            }
        }
    }
}

