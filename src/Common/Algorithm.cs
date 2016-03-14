using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CheckSum.Common
{
    public abstract class Algorithm
    {

        #region Fields

        public static readonly Algorithm MD5 = new Md5Algorithm();
        public static readonly Algorithm SHA2 = new Sha2Algorithm();
        public static readonly Algorithm Undefined = new UndefinedAlgorithm();
        private readonly string ChecksumFileName = "checksum.txt";

        #endregion

        #region Constructors

        private Algorithm() {}

        #endregion

        #region Abstract methods

        public abstract string CreateHash(string directory);
        public abstract bool IsValid();

        #endregion

        #region Overrideable methods

        public virtual bool AreHashesEqual(string hashSearch, string hashOriginal)
        {
            return (hashSearch == hashOriginal);
        }

        #endregion

        #region Protected methods

        protected string ComputeHash(string directory, Func<byte[], byte[]> computeHashAction)
        {
            var hash = "";
            foreach (var file in Directory.EnumerateFiles(directory, "*.*", SearchOption.AllDirectories))
            {
                if (file.Contains(this.ChecksumFileName))
                {
                    continue;
                }
                hash += FromHashToString(computeHashAction(System.IO.File.ReadAllBytes(file)));
            }
            return FromHashToString(computeHashAction(System.Text.Encoding.Default.GetBytes(hash)));
        }

        protected string FromHashToString(byte[] rgbHash)
        {
            var hash = new StringBuilder(rgbHash.Length * 2);
            for (var ix = 0; ix < rgbHash.Length; ix++) {
                hash.Append(rgbHash[ix].ToString("x2"));
            }
            return hash.ToString();
        }

        #endregion

        private class Md5Algorithm : Algorithm
        {

            public override string CreateHash(string directory)
            {
                using (var md5 = System.Security.Cryptography.MD5.Create())
                {
                    return ComputeHash(directory, md5.ComputeHash);
                }
            }

            public override bool IsValid()
            {
                return true;
            }

        }

        private class Sha2Algorithm : Algorithm
        {
            public override string CreateHash(string directory)
            {
                using (var sha2 = new SHA256Managed())
                {
                    return ComputeHash(directory, sha2.ComputeHash);
                }
            }

            public override bool IsValid()
            {
                return true;
            }
        }

        private class UndefinedAlgorithm : Algorithm
        {
            public override string CreateHash(string directory)
            {
                return "";
            }

            public override bool IsValid()
            {
                return false;
            }
        }

    }
}