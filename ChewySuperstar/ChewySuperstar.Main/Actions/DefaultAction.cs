namespace ChewySuperstar.Main.Actions
{
    public class DefaultAction : EVEAction
    {
        protected override void ExecuteAction()
        {
        }

        public bool? HasExecutedSuccesfully()
        {
            return ExecuteStatus;
        }
    }
}
