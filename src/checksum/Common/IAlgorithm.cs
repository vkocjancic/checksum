namespace CheckSum.Common
{
    public interface IAlgorithm
    {

        string CreateHash(string directory);
        bool AreHashesEqual(string hashSearch, string hashOriginal);
        bool IsValid();

    }
}
