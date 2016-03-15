namespace CheckSum.IO
{
    public interface ICheckSumWriter
    {

        void WriteToFile(string hash, string directory, string fileName);

    }
}