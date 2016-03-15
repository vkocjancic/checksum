namespace CheckSum.IO
{
    public interface ICheckSumReader
    {

        string ReadHash(string directory, string fileName);

    }
}