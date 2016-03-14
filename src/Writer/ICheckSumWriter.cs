namespace CheckSum.Writer
{
    public interface ICheckSumWriter
    {

        void WriteToFile(string hash, string directory, string fileName);

    }
}