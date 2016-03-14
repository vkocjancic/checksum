namespace CheckSum.Writer
{
    public class FileWriter : ICheckSumWriter
    {
        public void WriteToFile(string hash, string directory, string fileName)
        {
            System.IO.File.WriteAllText(System.IO.Path.Combine(directory, fileName), hash);
        }
    }
}