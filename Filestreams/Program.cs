// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string assemblyPath = "pathtotheassembly";
using (FileStream fs = new FileStream(assemblyPath + "/FileRequest.txt", FileMode.Open, FileAccess.Read, FileShare.Read))
{
    byte[] buffer = new byte[fs.Length];
    int bytesToRead = (int)fs.Length;
    int bytesRead = 0;
    while(bytesToRead > 0)
    {
        int n = fs.Read(buffer, bytesRead, bytesToRead);
        if (n == 0) break;
        bytesRead += n;
        bytesToRead -= n;
    }

    bytesToRead = buffer.Length;
    Console.WriteLine("Read {0} bytes from original file", bytesRead);

    //Write the data
    using(FileStream fsWrite = new FileStream(assemblyPath + "/FileRequest.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
    {
        fsWrite.Write(buffer, 0, bytesRead);
    }
    Console.WriteLine("Wrote new file successfully");
}