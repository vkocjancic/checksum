namespace CheckSum.Common
{
    public abstract class ArgumentActionStatus
    {

        #region Fields

        public static readonly ArgumentActionStatus InvalidHash = new ArgumentActionStatusInvalidHash();
        public static readonly ArgumentActionStatus Success = new ArgumentActionStatusSuccess();

        #endregion

        #region Constructors

        private ArgumentActionStatus() { }

        #endregion

        #region Internal classes

        private class ArgumentActionStatusInvalidHash : ArgumentActionStatus
        {

            public override string ToString()
            {
                return "Checksums do not match";
            }

        }

        private class ArgumentActionStatusSuccess : ArgumentActionStatus
        {

            public override string ToString()
            {
                return "Success";
            }

        }

        #endregion

    }
}
