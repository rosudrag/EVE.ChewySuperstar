using System.Collections.Generic;
using ChewySuperstar.Main.Actions;
using LavishVMAPI;

namespace ChewySuperstar.Main
{
    public class EveActionExecutor : IExecuteEVEActions
    {
        public EveActionExecutor()
        {
            CurrentFrameCount = 0;
            Actions = new List<IEVEAction>();
        }

        private int CurrentFrameCount { get; set; }
        private IList<IEVEAction> Actions { get; }

        public void Schedule(IEVEAction action)
        {
            Actions.Add(action);
        }

        public void Execute()
        {
            IncrementFrameCount();
            var executedActions = ExecuteEveActions();
            DeQueueExecutedActions(executedActions);
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

        private void IncrementFrameCount()
        {
            CurrentFrameCount ++;
        }
    }
}