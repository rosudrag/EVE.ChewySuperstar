using ChewySuperstar.Main.Actions;
using NUnit.Framework;

namespace ChewySuperstar.Main.Tests
{
    [TestFixture]
    public class EVEActionExecutorTests
    {
        [Test]
        public void SchedulerActionListGetsEmptyAfterItExecutesThem()
        {
            var scheduler = new EveActionExecutor();

            Assert.DoesNotThrow(() => {scheduler.Execute();});
        }

        [Test]
        public void SchedulerCanScheduleAnAction()
        {
            var scheduler = new EveActionExecutor();

            var defaultAction = new DefaultAction();
            scheduler.Schedule(defaultAction);
            scheduler.Execute();

            Assert.True(defaultAction.HasExecutedSuccesfully());
        }

    }
}