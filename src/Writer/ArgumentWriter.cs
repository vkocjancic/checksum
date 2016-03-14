using System;
using CheckSum.Common;

namespace CheckSum.Writer
{
    public static class ArgumentWriter
    {

        #region Static methods

        public static void WriteUse(Argument argument, IOutputWriter writer)
        {
            writer.WriteLine("Usage: checksum action directory algorithm");
            writer.WriteLine("\nAction");
            writer.WriteLine("\tcreate (cr)\tcreate checksum file");
            writer.WriteLine("\tcheck (ch)\tcheck checksum file with calculated checksum");
            writer.WriteLine("\nAlgorithm");
            writer.WriteLine("\tmd5\t\tcalculate checksum using md5");
            writer.WriteLine("\tsha1\t\tcalculate checksum using sha1");
            writer.WriteLine("\tsha2\t\tcalculate checksum using sha2");
        }

        public static void LogException(Exception ex, IOutputWriter writer)
        {
            writer.WriteLine(ex.Message);
        }

        #endregion

    }
}