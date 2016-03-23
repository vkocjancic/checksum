using CheckSum.Common;
using NUnit.Framework;

namespace checksum.unit.test.Common
{
    [TestFixture]
    public class ArgumentActionStatusTest
    {
        
        [TestFixture]
        public class ArgumentActionStatusSuccesTest : ArgumentActionStatusTest
        {

            [Test]
            public void ToString_ReturnsTextSuccess()
            {
                Assert.AreEqual(ArgumentActionStatus.Success.ToString(), "Success");
            }

        }

        [TestFixture]
        public class ArgumentActionStatusInvalidHashTest : ArgumentActionStatusTest
        {

            [Test]
            public void ToString_ReturnsTextChecksumsDoNotMatch()
            {
                Assert.AreEqual(ArgumentActionStatus.InvalidHash.ToString(), "Checksums do not match");
            }

        }

    }
}
