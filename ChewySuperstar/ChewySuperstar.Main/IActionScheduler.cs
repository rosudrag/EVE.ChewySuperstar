namespace ChewySuperstar.Main
{
    public interface IActionScheduler
    {
        void Schedule(IEVEAction action);
        void Execute();
    }
}