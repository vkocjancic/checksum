using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using CheckSum.Common;
using CheckSum.Writer;

namespace CheckSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var argument = ArgumentFactory.Create(args);
            if (argument.AreValid())
            {
                try {
                    argument.Action.Execute(argument.Algorithm, argument.Directory, new FileWriter(), new FileReader());
                }
                catch (Exception ex)
                {
                    ArgumentWriter.LogException(ex, new ConsoleWriter());
                }
            }
            else
            {
                ArgumentWriter.WriteUse(argument, new ConsoleWriter());
            }
        }
    }
}