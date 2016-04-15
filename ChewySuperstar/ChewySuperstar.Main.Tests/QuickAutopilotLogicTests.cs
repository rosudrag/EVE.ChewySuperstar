using System.Runtime.InteropServices.ComTypes;
using ChewySuperstar.Main.Logic;
using DryIoc;
using NUnit.Framework;

namespace ChewySuperstar.Main.Tests
{
    [TestFixture]
    public class QuickAutopilotLogicTests
    {
        private readonly IContainer _container = IoCBootstrapperConfiguration.BootstrapIoCContainer();

        [Test]
        public void LogicCanRun()
        {
            var logic = _container.Resolve<IQuickAutopilotLogic>();

            Assert.DoesNotThrow(logic.Run);
        }

     }
}