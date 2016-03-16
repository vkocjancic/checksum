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

        public abstract void Execute(IAlgorithm algorithm, string directory, ICheckSumWriter writer, ICheckSumReader reader);
        public abstract bool IsValid();

        #endregion

        private class CreateArgumentAction : ArgumentAction
        {
            public override void Execute(IAlgorithm algorithm, string directory, ICheckSumWriter writer, ICheckSumReader reader)
            {
                var hash = algorithm.CreateHash(directory);
                writer.WriteToFile(hash, directory, "checksum.txt");
            }

            public override bool IsValid()
            {
                return true;
            }

        }

        private class CheckArgumentAction : ArgumentAction
        {
            public override void Execute(IAlgorithm algorithm, string directory, ICheckSumWriter writer, ICheckSumReader reader)
            {
                var hash = algorithm.CreateHash(directory);
                var hashOriginal = reader.ReadHash(directory, "checksum.txt");
                if (!algorithm.AreHashesEqual(hash, hashOriginal))
                {
                    throw new InvalidCheckSumException("Checksums do not match");
                }
            }

            public override bool IsValid()
            {
                return true;
            }
        }

        private class UndefinedArgumentAction : ArgumentAction
        {
            public override void Execute(IAlgorithm algorithm, string directory, ICheckSumWriter writer, ICheckSumReader reader)
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