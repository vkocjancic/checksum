using CheckSum.Common;
using NUnit.Framework;

namespace checksum.unit.test.Common
{
    [TestFixture]
    public class ArgumentFactoryTest
    {
        [Test]
        public void Create_ReturnsArgumentInstance()
        {
            var argument = ArgumentFactory.Create(new string[] { });
            Assert.IsInstanceOf(typeof(Argument), argument);
        }
    }
}
