using LavishScriptAPI;

namespace ChewySuperstar.Main
{
    public interface IEVEBootstrap
    {
        void HookToGameClient();
    }

    public class EVEBootstrap : IEVEBootstrap
    {
        private readonly IExecuteEVEActions _executeEVEActions;

        public EVEBootstrap(IExecuteEVEActions executeEVEActions)
        {
            _executeEVEActions = executeEVEActions;
            //var defaultAction = new DefaultAction();
            //ActionScheduler = new EveActionExecutor(defaultAction, 60);
            //ActionScheduler.Schedule(new DScanAction());
        }

        public void HookToGameClient()
        {
            var onFrameEvent = LavishScript.Events.RegisterEvent("ISXEVE_onFrame");
            LavishScript.Events.AttachEventTarget(onFrameEvent, OnFrame);
        }

        private void OnFrame(object sender, LSEventArgs e)
        {
            _executeEVEActions.Execute();
        }
    }
}