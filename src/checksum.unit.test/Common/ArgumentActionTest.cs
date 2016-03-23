using CheckSum.Common;
using CheckSum.IO;
using Moq;
using NUnit.Framework;
using System;

namespace checksum.unit.test.Common
{
    [TestFixture]
    public class ArgumentActionTest
    {

        #region Fields

        Mock<IAlgorithm> m_algorithm;
        Mock<ICheckSumReader> m_reader;
        Mock<ICheckSumWriter> m_writer;

        #endregion

        [OneTimeSetUp]
        public void SetUp()
        {
            m_algorithm = new Mock<IAlgorithm>();
            m_reader = new Mock<ICheckSumReader>();
            m_writer = new Mock<ICheckSumWriter>();
            m_algorithm.Setup(a => a.CreateHash(It.IsAny<string>())).Returns("abc");
            m_writer.Setup(w => w.WriteToFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
        }


        [TestFixture]
        public class ArgumentActionCheckTest : ArgumentActionTest
        {
            [Test]
            public void Execute_HashesAreNotEqual_returnsStatusInvalidHash()
            {
                m_algorithm.ResetCalls();
                m_reader.ResetCalls();
                m_reader.Setup(r => r.ReadHash(It.IsAny<string>(), It.IsAny<string>())).Returns("cba");
                m_algorithm.Setup(a => a.AreHashesEqual(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
                var result = ArgumentAction.Check.Execute(m_algorithm.Object, "directory", m_writer.Object, m_reader.Object);
                Assert.AreEqual(ArgumentActionStatus.InvalidHash, result.Status);
                m_reader.Verify(x => x.ReadHash("directory", "checksum.txt"), Times.Once());
                m_algorithm.Verify(x => x.CreateHash("directory"), Times.Once());
                m_algorithm.Verify(x => x.AreHashesEqual("abc", "cba"), Times.Once());
            }

            [Test]
            public void Execute_HashesAreEqual_returnsStatusSuccess()
            {
                m_algorithm.ResetCalls();
                m_reader.ResetCalls();
                m_reader.Setup(r => r.ReadHash(It.IsAny<string>(), It.IsAny<string>())).Returns("abc");
                m_algorithm.Setup(a => a.AreHashesEqual(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
                var result = ArgumentAction.Check.Execute(m_algorithm.Object, "directory", m_writer.Object, m_reader.Object);
                Assert.AreEqual(ArgumentActionStatus.Success, result.Status);
                m_reader.Verify(x => x.ReadHash("directory", "checksum.txt"), Times.Once());
                m_algorithm.Verify(x => x.CreateHash("directory"), Times.Once());
                m_algorithm.Verify(x => x.AreHashesEqual("abc", "abc"), Times.Once());
            }

            [Test]
            public void IsValid_returnsTrue()
            {
                var action = ArgumentAction.Check;
                Assert.IsTrue(action.IsValid());
            }
        }

        [TestFixture]
        public class ArgumentActionCreateTest : ArgumentActionTest
        {
            [Test]
            public void Execute_CallsComputeHashAndWritesToFile()
            {
                m_algorithm.ResetCalls();
                m_writer.ResetCalls();
                var action = ArgumentAction.Create;
                action.Execute(m_algorithm.Object, "directory", m_writer.Object, null);
                m_algorithm.Verify(x => x.CreateHash("directory"), Times.Once());
                m_writer.Verify(x => x.WriteToFile("abc", "directory", "checksum.txt"), Times.Once());
            }

            [Test]
            public void IsValid_returnsTrue()
            {
                var action = ArgumentAction.Create;
                Assert.IsTrue(action.IsValid());
            }
        }

        [TestFixture]
        public class ArgumentActionUndefinedTest : ArgumentActionTest
        {
            [Test]
            public void Execute_throwsNotImplementedException()
            {
                m_algorithm.ResetCalls();
                var action = ArgumentAction.Undefined;
                Assert.Throws<NotImplementedException>(() =>
                    action.Execute(m_algorithm.Object, "directory", m_writer.Object, m_reader.Object));
            }

            [Test]
            public void IsValid_returnsFalse()
            {
                var action = ArgumentAction.Undefined;
                Assert.IsFalse(action.IsValid());
            }
        }

    }
}
