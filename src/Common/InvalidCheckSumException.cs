using System;

namespace CheckSum.Common
{

    public class InvalidCheckSumException : ApplicationException
    {

        #region Constructors

        public InvalidCheckSumException(string errorMessage) : base(errorMessage) { }

        #endregion

    }

}