
namespace CheckSum.Common
{
    public class Argument
    {

        #region Properties

        private string[] Arguments { get; set; }
        public ArgumentAction Action { get; private set; }
        public Algorithm Algorithm { get; private set; }
        public string Directory { get; private set; }

        #endregion

        #region Constructors

        public Argument(string[] args)
        {
            this.Arguments = args;
        }

        #endregion

        #region Public methods

        public bool AreValid()
        {
            var areValid = false;
            if (3 == Arguments.Length)
            {
                this.Action = ArgumentActionFactory.Create(Arguments[0]);
                this.Algorithm = AlgorithmFactory.Create(Arguments[2]);
                this.Directory = Arguments[1];
                areValid = ((this.Action.IsValid())
                    && (this.Algorithm.IsValid())
                    && (!string.IsNullOrEmpty(this.Directory)));
            }
            return areValid;
        }

        #endregion

    }
}