using System;
using CheckSum.IO;

namespace CheckSum.Common
{
    public static class AlgorithmFactory
    {
        #region Static methods

        public static Algorithm Create(string algorithmName) {
            var algorithm = Algorithm.Undefined;
            if (null != algorithmName)
            {
                algorithmName = algorithmName.ToLower();
                if (algorithmName == "md5")
                {
                    algorithm = Algorithm.MD5;
                }
                else if (algorithmName == "sha1")
                {
                    algorithm = Algorithm.SHA1;
                }
                else if (algorithmName == "sha2")
                {
                    algorithm = Algorithm.SHA2;
                }
            }
            return algorithm;
        }

        #endregion
    }
}