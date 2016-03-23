using CheckSum.IO;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checksum.unit.test.IO
{
    [TestFixture]
    public class ArgumentWriterTest
    {

        #region Fields

        Mock<IOutputWriter> m_wriConsole;

        #endregion

        [OneTimeSetUp]
        public void SetUp()
        {
            m_wriConsole = new Mock<IOutputWriter>();
            m_wriConsole.Setup(w => w.WriteLine(It.IsAny<string>()));
        }

        [TestFixture]
        public class WriteUseTest : ArgumentWriterTest
        {

            [Test]
            public void WriteUse_OutputsWriteUse()
            {
                ArgumentWriter.WriteUse(m_wriConsole.Object);
                m_wriConsole.Verify(x => x.WriteLine("Usage: checksum action directory algorithm"), Times.Once());
                m_wriConsole.Verify(x => x.WriteLine("\nAction"), Times.Once());
                m_wriConsole.Verify(x => x.WriteLine("\tcreate (cr)\tcreate checksum file"), Times.Once());
                m_wriConsole.Verify(x => x.WriteLine("\tcheck (ch)\tcheck checksum file with calculated checksum"), Times.Once());
                m_wriConsole.Verify(x => x.WriteLine("\nAlgorithm"), Times.Once());
                m_wriConsole.Verify(x => x.WriteLine("\tmd5\t\tcalculate checksum using md5"), Times.Once());
                m_wriConsole.Verify(x => x.WriteLine("\tsha1\t\tcalculate checksum using sha1"), Times.Once());
                m_wriConsole.Verify(x => x.WriteLine("\tsha2\t\tcalculate checksum using sha2"), Times.Once());
            }

        }

        [TestFixture]
        public class LogException : ArgumentWriterTest
        {

            [Test]
            public void LogException_OutputsExceptionMessage()
            {
                var ex = new Exception("test");
                ArgumentWriter.LogException(ex, m_wriConsole.Object);
                m_wriConsole.Verify(x => x.WriteLine(ex.Message), Times.Once());
            }

        }

    }
}
