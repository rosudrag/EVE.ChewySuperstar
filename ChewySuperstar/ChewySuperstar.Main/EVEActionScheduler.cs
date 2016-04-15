using System.Collections.Generic;
using LavishVMAPI;

namespace ChewySuperstar.Main
{
    public class EveActionScheduler : IActionScheduler
    {
        public EveActionScheduler()
        {
            DefaultAction = new DefaultAction();
            DefaultActionFrameNumber = 60;
            Actions = new List<IEVEAction>();
        }

        private int CurrentFrameCount { get; set; }
        private DefaultAction DefaultAction { get; set; }
        private int DefaultActionFrameNumber { get; set; }
        private IList<IEVEAction> Actions { get; }

        public void Schedule(IEVEAction action)
        {
            Actions.Add(action);
        }

        public int ScheduledActions()
        {
            return Actions.Count;
        }

        public void Execute()
        {
            IncrementFrameCount();
            var executedActions = ExecuteEveActions();
            DeQueueExecutedActions(executedActions);
            ScheduleDefaultActionIfZeroFrameCount();
        }

        private List<IEVEAction> ExecuteEveActions()
        {
            var executedActions = new List<IEVEAction>();

            foreach (var eveAction in Actions)
            {
                eveAction.Execute();
                executedActions.Add(eveAction);
            }
            return executedActions;
        }

        private void DeQueueExecutedActions(List<IEVEAction> executedActions)
        {
            foreach (var executedAction in executedActions)
            {
                Actions.Remove(executedAction);
            }
        }

        private void ScheduleDefaultActionIfZeroFrameCount()
        {
            if (CurrentFrameCount == 0)
            {
                Schedule(DefaultAction);
            }
        }

        private void IncrementFrameCount()
        {
            CurrentFrameCount = (CurrentFrameCount + 1)%DefaultActionFrameNumber;
        }
    }
}