using System.IO.Compression;

namespace GZipStreamnamespace
{
    internal class Program
    {
        private static readonly string assemblyPath;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        private static void AZippierStream()
        {
            FileInfo fi = new FileInfo(assemblyPath + "/sharedfolder/bigfile.txt");

            long squished_file_size = GZippy.SquishIt(fi);
        }
    }

    public class GZippy
    {
        public static long SquishIt(FileInfo unsquished_file)
        {
            using(FileStream unsquished_stream = unsquished_file.OpenRead())
            {
                Console.WriteLine(File.GetAttributes(unsquished_file.FullName).ToString());
                Console.WriteLine(FileAttributes.Hidden);
                Console.WriteLine(unsquished_file.Extension);
                Console.ReadKey();

                long squished_length = 0;
                if((File.GetAttributes(unsquished_file.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden 
                    && unsquished_file.Extension !=".gz") 
                {
                    using (FileStream squished_stream = File.Create(unsquished_file.FullName + ".gz"))
                    {
                        using (GZipStream squisher = new GZipStream(squished_stream, CompressionMode.Compress))
                        {
                            unsquished_stream.CopyTo(squisher);
                            Console.WriteLine("Original File {0} was {1} bytes" + "now its {2} bytes",
                                unsquished_file.Name, unsquished_file.Length.ToString(), squished_stream.Length.ToString());
                            squished_length = squished_stream.Length;
                        }
                    }
                }
                return squished_length;
            }
        }
    }
}
