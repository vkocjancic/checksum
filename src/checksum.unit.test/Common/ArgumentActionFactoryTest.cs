using CheckSum.Common;
using NUnit.Framework;

namespace checksum.unit.test.Common
{
    [TestFixture]
    public class ArgumentActionFactoryTest
    {
        [Test]
        public void ArgumentAction_ActionIsNull_returnsUndefinedAction()
        {
            var action = ArgumentActionFactory.Create(null);
            Assert.IsInstanceOf(ArgumentAction.Undefined.GetType(), action);
        }

        [Test]
        public void ArgumentAction_ActionIsUndefined_returnsUndefinedAction()
        {
            var action = ArgumentActionFactory.Create("foo");
            Assert.IsInstanceOf(ArgumentAction.Undefined.GetType(), action);
        }

        [Test]
        public void ArgumentAction_ActionIsCreate_returnsCreateAction()
        {
            var action = ArgumentActionFactory.Create("CR");
            Assert.IsInstanceOf(ArgumentAction.Create.GetType(), action, "CR");
            action = ArgumentActionFactory.Create("cr");
            Assert.IsInstanceOf(ArgumentAction.Create.GetType(), action, "cr");
            action = ArgumentActionFactory.Create("CREATE");
            Assert.IsInstanceOf(ArgumentAction.Create.GetType(), action, "CREATE");
            action = ArgumentActionFactory.Create("create");
            Assert.IsInstanceOf(ArgumentAction.Create.GetType(), action, "create");
        }

        [Test]
        public void ArgumentAction_ActionIsCheck_returnsCheckAction()
        {
            var action = ArgumentActionFactory.Create("CH");
            Assert.IsInstanceOf(ArgumentAction.Check.GetType(), action, "CH");
            action = ArgumentActionFactory.Create("ch");
            Assert.IsInstanceOf(ArgumentAction.Check.GetType(), action, "ch");
            action = ArgumentActionFactory.Create("CHECK");
            Assert.IsInstanceOf(ArgumentAction.Check.GetType(), action, "CHECK");
            action = ArgumentActionFactory.Create("check");
            Assert.IsInstanceOf(ArgumentAction.Check.GetType(), action, "check");
        }
    }
}
