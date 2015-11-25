using NUnit.Framework;

namespace ChewySuperstar.Main.Tests
{
    [TestFixture]
    public class EVEBootstrapTests
    {
        [Test]
        public void CreatingClientBootstrapIsSuccesful()
        {
            Assert.DoesNotThrow(() => { new EVEBootstrap(); });
        }

        [Test]
        public void ClientBootstrapCanHookToGameClient()
        {
            var bootstrap = new EVEBootstrap();
            Assert.DoesNotThrow(bootstrap.HookToGameClient);
        }
    }
}