using ChewySuperstar.Main.Actions;

namespace ChewySuperstar.Main
{
    public interface IExecuteEVEActions
    {
        void Schedule(IEVEAction action);
        void Execute();
    }
}