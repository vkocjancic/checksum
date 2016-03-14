using System;
using CheckSum.Common;

namespace CheckSum.Writer
{
    public static class ArgumentWriter
    {

        #region Static methods

        public static void WriteUse(Argument argument, IOutputWriter writer)
        {
            writer.WriteLine("Usage: checksum cr|create|ch|check directory md5|sha2");
        }

        public static void LogException(Exception ex, IOutputWriter writer)
        {
            writer.WriteLine(ex.Message);
        }

        #endregion

    }
}