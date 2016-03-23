using System;
using CheckSum.Common;
using CheckSum.IO;

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
                    var result = argument.Action.Execute(argument.Algorithm, argument.Directory, new FileWriter(), new FileReader());
                    ArgumentWriter.WriteResult(result, new ConsoleWriter());
                }
                catch (Exception ex)
                {
                    ArgumentWriter.LogException(ex, new ConsoleWriter());
                }
            }
            else
            {
                ArgumentWriter.WriteUse(new ConsoleWriter());
            }
        }
    }
}