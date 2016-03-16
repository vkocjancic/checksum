using CheckSum.Common;
using NUnit.Framework;

namespace checksum.unit.test.Common
{
    [TestFixture]
    public class AlgorithmTest
    {
        
        [TestFixture]
        public class Md5AlgorithmTest : AlgorithmTest
        {

            [Test]
            public void IsValid_returnsTrue()
            {
                var algorithm = Algorithm.MD5;
                Assert.IsTrue(algorithm.IsValid());
            }

        }

        [TestFixture]
        public class Sha1AlgorithmTest : AlgorithmTest
        {

            [Test]
            public void IsValid_returnsTrue()
            {
                var algorithm = Algorithm.SHA1;
                Assert.IsTrue(algorithm.IsValid());
            }

        }

        [TestFixture]
        public class Sha2AlgorithmTest : AlgorithmTest
        {
            [Test]
            public void IsValid_returnsTrue()
            {
                var algorithm = Algorithm.SHA2;
                Assert.IsTrue(algorithm.IsValid());
            }
        }

        [TestFixture]
        public class UndefinedAlgorithmTest : AlgorithmTest
        {
            [Test]
            public void IsValid_returnsFalse()
            {
                var algorithm = Algorithm.Undefined;
                Assert.IsFalse(algorithm.IsValid());
            }
        }

    }
}
