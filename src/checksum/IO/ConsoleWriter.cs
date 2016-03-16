using System;

namespace CheckSum.IO
{
    public class ConsoleWriter : IOutputWriter
    {

        #region IOutputWriter implementation

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }

        #endregion

    }
}