namespace CheckSum.Common
{

    public static class ArgumentFactory
    {

        #region Public methods

        public static Argument Create(string[] args)
        {
            return new Argument(args);
        }

        #endregion

    }

}