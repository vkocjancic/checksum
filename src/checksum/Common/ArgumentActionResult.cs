using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckSum.Common
{
    public class ArgumentActionResult
    {

        #region Properties

        public ArgumentActionStatus Status { get; set; }

        #endregion

        #region Constructors

        public ArgumentActionResult(ArgumentActionStatus status)
        {
            this.Status = status;
        }

        #endregion

    }
}
