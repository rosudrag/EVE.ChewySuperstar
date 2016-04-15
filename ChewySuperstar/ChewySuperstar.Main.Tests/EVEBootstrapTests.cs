using DryIoc;
using NSubstitute;
using NUnit.Framework;

namespace ChewySuperstar.Main.Tests
{
    [TestFixture]
    public class EVEBootstrapTests
    {
        [Test]
        public void ClientBootstrapCanHookToGameClient()
        {
            var actionScheduler = Substitute.For<IActionScheduler>();
            var bootstrap = new EVEBootstrap(actionScheduler);
            Assert.DoesNotThrow(bootstrap.HookToGameClient);
        }

        [Test]
        public void IoCRegistrationIsSuccesfull()
        {
            var container = IoCBootstrapperConfiguration.BootstrapIoCContainer();
            Assert.DoesNotThrow(() => { container.Resolve<IEVEBootstrap>(); });
    }
}