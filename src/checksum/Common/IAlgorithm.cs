namespace CheckSum.Common
{
    public interface IAlgorithm
    {
        #region Properties

        string OutputFileName { get; }

        #endregion

        #region Methods

        string CreateHash(string directory);
        bool AreHashesEqual(string hashSearch, string hashOriginal);
        bool IsValid();

        #endregion
        
    }
}
