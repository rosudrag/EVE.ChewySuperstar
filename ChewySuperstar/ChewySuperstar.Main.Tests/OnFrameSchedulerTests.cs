using NUnit.Framework;

namespace ChewySuperstar.Main.Tests
{
    [TestFixture]
    public class OnFrameSchedulerTests
    {
        private readonly DefaultAction defaultAction = new DefaultAction();
        private int defaultActionFrameNumber = 1;

        [Test]
        public void SchedulerActionListGetsEmptyAfterItExecutesThem()
        {
            var scheduler = new OnFrameScheduler(defaultAction, defaultActionFrameNumber+1);
            scheduler.Execute();

            Assert.AreEqual(scheduler.ScheduledActions(), 0);
        }

        [Test]
        public void SchedulerCanScheduleAnAction()
        {
            var scheduler = new OnFrameScheduler(defaultAction, defaultActionFrameNumber);

            scheduler.Schedule(defaultAction);
            Assert.Greater(scheduler.ScheduledActions(), 0);
        }

        [Test]
        public void SchedulerExecutesDefaultActionEveryPredefinedFrames()
        {
            var scheduler =  new OnFrameScheduler(defaultAction, defaultActionFrameNumber);

            for (int i = 0; i < defaultActionFrameNumber; i++)
            {
                scheduler.Execute();
            }

            Assert.Greater(scheduler.ScheduledActions(), 0);
        }

        [Test]
        //To do implement extra eve actions and test scheduler executes them
        public void SchedulerCanExecuteDScanAction()
        {
            var scheduler = new OnFrameScheduler(defaultAction, defaultActionFrameNumber);
            var dscanAction = new DScanAction();
            scheduler.Schedule(dscanAction);
            Assert.Greater(scheduler.ScheduledActions(), 0);
        }
    }
}