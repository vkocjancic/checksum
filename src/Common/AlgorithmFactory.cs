using System;
using CheckSum.Writer;

namespace CheckSum.Common
{
    public static class AlgorithmFactory
    {
        #region Static methods

        public static Algorithm Create(string algorithmName) {
            algorithmName = algorithmName.ToLower();
            var algorithm = Algorithm.Undefined;
            if (algorithmName == "md5")
            {
                algorithm = Algorithm.MD5;
            }
            else if (algorithmName == "sha2")
            {
                algorithm = Algorithm.SHA2;
            }
            return algorithm;
        }

        #endregion
    }
}