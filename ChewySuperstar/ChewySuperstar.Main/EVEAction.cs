using System;
using InnerSpaceAPI;

namespace ChewySuperstar.Main
{
    public abstract class EVEAction : IEVEAction
    {
        private int executeCount;

        protected virtual string ActionName { get { return GetType().Name; } }

        public void Execute()
        {
            ExecuteAction();
            LogExecuteCount();
        }

        private void LogExecuteCount()
        {
            InnerSpace.Echo(string.Format("{0:HH:mm:ss} {1} Execute Count: {2}", DateTime.Now, ActionName, ++executeCount));
        }

        protected abstract void ExecuteAction();
    }
}