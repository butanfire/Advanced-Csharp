namespace Problem_5.Slicing_File
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class SlicingFile
    {
        public static void Main(string[] args)
        {
            string fileName = "picture.png";
            string destinationDirectory = @"../sliced/";
            int sliceParts = int.Parse(Console.ReadLine());
            var sliced = Slice(fileName, destinationDirectory, sliceParts);
            Assemble(sliced, destinationDirectory);
        }

        public static List<string> Slice(string sourceFile, string destinationDirectory, int sliceParts)
        {
            Directory.CreateDirectory(destinationDirectory);

            var files = new List<string>();

            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                for (int i = 0; i < sliceParts; i++)
                {
                    var maxSlice = (int)Math.Ceiling((double)source.Length / sliceParts);

                    var destFile = sourceFile.Split('.');
                    string destinationFile = destinationDirectory + destFile[0] + "-" + i + "." + destFile[1];

                    using (var destination = new FileStream(destinationFile, FileMode.Create))
                    {
                        byte[] buffer = new byte[maxSlice];

                        var readBytes = 0;
                        if ((readBytes = source.Read(buffer, 0, maxSlice)) > 0)
                        {
                            destination.Write(buffer, 0, readBytes);
                        }
                    }

                    files.Add(destinationFile);
                }
            }

            return files;
        }

        public static void Assemble(List<string> files, string destinationDirectory)
        {
            string outputFileName = "Assembled.jpg";
            File.Delete(destinationDirectory + outputFileName);

            foreach (var file in files)
            {
                var destinationFile = destinationDirectory + outputFileName;

                using (var output = new FileStream(destinationFile, FileMode.Append))
                {
                    using (var source = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
                        int bytesRead = 0;
                        byte[] buffer = new byte[4096];

                        while ((bytesRead = source.Read(buffer, 0, 4096)) > 0)
                        {
                            output.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
        }
    }
}
