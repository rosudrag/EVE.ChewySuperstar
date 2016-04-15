using System;
using InnerSpaceAPI;
using LavishVMAPI;

namespace ChewySuperstar.Main
{
    public abstract class EVEAction : IEVEAction
    {
        protected virtual string ActionName => GetType().Name;

        public void Execute()
        {
            ExecuteAction();
            LogExecuteCount();
            ExecuteStatus = true;
        }

        public bool ExecuteStatus { get; set; }

        private void LogExecuteCount()
        {
            InnerSpace.Echo($"{DateTime.Now:HH:mm:ss} {ActionName}");
        }

        protected abstract void ExecuteAction();
    }
}