using CheckSum.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checksum.unit.test.Common
{
    [TestFixture]
    public class ArgumentActionResultTest
    {

        [TestFixture]
        public class ConstructorTest : ArgumentActionResultTest
        {

            [Test]
            public void StatusPassed_StatusSet()
            {
                var result = new ArgumentActionResult(ArgumentActionStatus.Success);
                Assert.IsInstanceOf(ArgumentActionStatus.Success.GetType(), result.Status);
                Assert.IsNotNull(result.Status);
            }

        }

    }
}
