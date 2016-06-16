namespace Problem_6.Zipping_Sliced_Files
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;

    public class ZipSlicingFile
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
                    string destinationFile = destinationDirectory + destFile[0] + "-" + i + ".gz";

                    using (var destination = new FileStream(destinationFile, FileMode.Create))
                    {
                        using (var compressionStream = new GZipStream(destination, CompressionMode.Compress, false))
                        {
                            byte[] buffer = new byte[maxSlice];

                            var readBytes = 0;
                            if ((readBytes = source.Read(buffer, 0, maxSlice)) > 0)
                            {
                                compressionStream.Write(buffer, 0, readBytes);
                            }
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
                using (var source = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    using (var compressionStream = new GZipStream(source, CompressionMode.Decompress, false))
                    {
                        using (var output = new FileStream(destinationFile, FileMode.Append))
                        {
                            int bytesRead = 0;
                            byte[] buffer = new byte[4096];

                            while ((bytesRead = compressionStream.Read(buffer, 0, 4096)) > 0)
                            {
                                output.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                }
            }
        }

    }
}
