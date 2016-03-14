namespace CheckSum.Writer
{
    public interface ICheckSumReader
    {

        string ReadHash(string directory, string fileName);

    }
}