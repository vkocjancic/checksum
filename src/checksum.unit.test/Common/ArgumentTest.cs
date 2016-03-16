using CheckSum.Common;
using NUnit.Framework;

namespace checksum.unit.test.Common
{
    [TestFixture]
    public class ArgumentTest
    {
        [Test]
        public void AreValid_NoParams_ReturnsFalse()
        {
            var argument = new Argument(new string[] { });
            Assert.IsFalse(argument.AreValid());
        }

        [Test]
        public void AreValid_TooFewParamsSet_ReturnsFalse()
        {
            var argument = new Argument(new string[] { "param1" });
            Assert.IsFalse(argument.AreValid(), "Number of arguments: 1");
            argument = new Argument(new string[] { "param1", "param2" });
            Assert.IsFalse(argument.AreValid(), "Number of arguments: 2");
        }

        [Test]
        public void AreValid_TooManyParamsSet_ReturnsFalse()
        {
            var argument = new Argument(new string[] { "param1", "param2", "param3", "param4" });
            Assert.IsFalse(argument.AreValid(), "Number of arguments: 4");
        }

        [Test]
        public void AreValid_NumberOfParamsOK_ParamsInvalid_ReturnsFalse()
        {
            var argument = new Argument(new string[] { "param1", "param2", "param3" });
            Assert.IsFalse(argument.AreValid());
        }

        [Test]
        public void AreValid_CreateMd5Checksum_ReturnsTrue()
        {
            var argument = new Argument(new string[] { "create", "directory", "md5" });
            Assert.IsTrue(argument.AreValid(), "Long action name");
            argument = new Argument(new string[] { "cr", "directory", "md5" });
            Assert.IsTrue(argument.AreValid(), "short action name");
        }

        [Test]
        public void AreValid_CreateSha1Checksum_ReturnsTrue()
        {
            var argument = new Argument(new string[] { "create", "directory", "sha1" });
            Assert.IsTrue(argument.AreValid(), "Long action name");
            argument = new Argument(new string[] { "cr", "directory", "sha1" });
            Assert.IsTrue(argument.AreValid(), "short action name");
        }

        [Test]
        public void AreValid_CreateSha2Checksum_ReturnsTrue()
        {
            var argument = new Argument(new string[] { "create", "directory", "sha2" });
            Assert.IsTrue(argument.AreValid(), "Long action name");
            argument = new Argument(new string[] { "cr", "directory", "sha2" });
            Assert.IsTrue(argument.AreValid(), "short action name");
        }

        [Test]
        public void AreValid_CheckMd5Checksum_ReturnsTrue()
        {
            var argument = new Argument(new string[] { "check", "directory", "md5" });
            Assert.IsTrue(argument.AreValid(), "Long action name");
            argument = new Argument(new string[] { "ch", "directory", "md5" });
            Assert.IsTrue(argument.AreValid(), "short action name");
        }

        [Test]
        public void AreValid_CheckSha1Checksum_ReturnsTrue()
        {
            var argument = new Argument(new string[] { "check", "directory", "sha1" });
            Assert.IsTrue(argument.AreValid(), "Long action name");
            argument = new Argument(new string[] { "ch", "directory", "sha1" });
            Assert.IsTrue(argument.AreValid(), "short action name");
        }

        [Test]
        public void AreValid_CheckSha2Checksum_ReturnsTrue()
        {
            var argument = new Argument(new string[] { "check", "directory", "sha2" });
            Assert.IsTrue(argument.AreValid(), "Long action name");
            argument = new Argument(new string[] { "ch", "directory", "sha2" });
            Assert.IsTrue(argument.AreValid(), "short action name");
        }
    }
}
