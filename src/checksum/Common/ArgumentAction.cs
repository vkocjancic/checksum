using System;
using CheckSum.IO;

namespace CheckSum.Common
{
    public abstract class ArgumentAction
    {
        #region Fields

        public static readonly ArgumentAction Create = new CreateArgumentAction();
        public static readonly ArgumentAction Check = new CheckArgumentAction();
        public static readonly ArgumentAction Undefined = new UndefinedArgumentAction();

        #endregion

        #region Constructors

        private ArgumentAction() {}

        #endregion

        #region Abstract methods

        public abstract ArgumentActionResult Execute(IAlgorithm algorithm, string directory, ICheckSumWriter writer, ICheckSumReader reader);
        public abstract bool IsValid();

        #endregion

        private class CreateArgumentAction : ArgumentAction
        {
            public override ArgumentActionResult Execute(IAlgorithm algorithm, string directory, ICheckSumWriter writer, ICheckSumReader reader)
            {
                var hash = algorithm.CreateHash(directory);
                writer.WriteToFile(hash, directory, algorithm.OutputFileName);
                return new ArgumentActionResult(ArgumentActionStatus.Success);
            }

            public override bool IsValid()
            {
                return true;
            }

        }

        private class CheckArgumentAction : ArgumentAction
        {
            public override ArgumentActionResult Execute(IAlgorithm algorithm, string directory, ICheckSumWriter writer, ICheckSumReader reader)
            {
                var hash = algorithm.CreateHash(directory);
                var hashOriginal = reader.ReadHash(directory, algorithm.OutputFileName);
                if (!algorithm.AreHashesEqual(hash, hashOriginal))
                {
                    return new ArgumentActionResult(ArgumentActionStatus.InvalidHash);
                }
                return new ArgumentActionResult(ArgumentActionStatus.Success);
            }

            public override bool IsValid()
            {
                return true;
            }
        }

        private class UndefinedArgumentAction : ArgumentAction
        {
            public override ArgumentActionResult Execute(IAlgorithm algorithm, string directory, ICheckSumWriter writer, ICheckSumReader reader)
            {
                throw new NotImplementedException();
            }

            public override bool IsValid()
            {
                return false;
            }
        }

    }
}