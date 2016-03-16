using CheckSum.Common;
using NUnit.Framework;

namespace checksum.unit.test.Common
{
    [TestFixture]
    public class AlgorithmFactoryTest
    {
        [Test]
        public void Create_AlgorithmNull_ReturnsUndefined()
        {
            var algorithm = AlgorithmFactory.Create(null);
            Assert.IsInstanceOf(Algorithm.Undefined.GetType(), algorithm);
        }

        [Test]
        public void Crreate_AlgorithmUndefined_ReturnsUndefined()
        {
            var algorithm = AlgorithmFactory.Create("foo");
            Assert.IsInstanceOf(Algorithm.Undefined.GetType(), algorithm);
        }

        [Test]
        public void Crreate_AlgorithmMd5_ReturnsMD5Algorithm()
        {
            var algorithm = AlgorithmFactory.Create("MD5");
            Assert.IsInstanceOf(Algorithm.MD5.GetType(), algorithm, "MD5");
            algorithm = AlgorithmFactory.Create("md5");
            Assert.IsInstanceOf(Algorithm.MD5.GetType(), algorithm, "md5");
        }

        [Test]
        public void Crreate_AlgorithmSha1_ReturnsSHA1Algorithm()
        {
            var algorithm = AlgorithmFactory.Create("SHA1");
            Assert.IsInstanceOf(Algorithm.SHA1.GetType(), algorithm, "SHA1");
            algorithm = AlgorithmFactory.Create("sha1");
            Assert.IsInstanceOf(Algorithm.SHA1.GetType(), algorithm, "sha1");
        }

        [Test]
        public void Crreate_AlgorithmSha2_ReturnsSHA2Algorithm()
        {
            var algorithm = AlgorithmFactory.Create("SHA2");
            Assert.IsInstanceOf(Algorithm.SHA2.GetType(), algorithm, "SHA2");
            algorithm = AlgorithmFactory.Create("sha2");
            Assert.IsInstanceOf(Algorithm.SHA2.GetType(), algorithm, "SHA2");
        }
    }
}
