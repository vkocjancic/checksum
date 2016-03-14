namespace CheckSum.Writer
{
    public class FileReader : ICheckSumReader
    {

        #region ICheckSumReader implementation

        public string ReadHash(string directory, string fileName)
        {
            return System.IO.File.ReadAllText(System.IO.Path.Combine(directory, fileName));
        }

        #endregion

    }
}