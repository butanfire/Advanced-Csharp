namespace Problem_4.Copy_Binary_File
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        public static void Main(string[] args)
        {
            var sourceFile = @"picture.png";
            var destinationFile = @"pictureCopy.png";

            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                using (var destination = new FileStream(destinationFile, FileMode.Create))
                {
                    double fileLength = source.Length;
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }

                        destination.Write(buffer, 0, readBytes);

                        Console.WriteLine("{0:P}", Math.Min(source.Position / fileLength, 1));
                    }
                }
            }
        }
    }
}
