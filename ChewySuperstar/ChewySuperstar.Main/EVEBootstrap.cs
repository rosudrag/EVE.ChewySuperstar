using LavishScriptAPI;

namespace ChewySuperstar.Main
{
    public interface IEVEBootstrap
    {
        void HookToGameClient();
    }

    public class EVEBootstrap : IEVEBootstrap
    {
        private readonly IActionScheduler _actionScheduler;

        public EVEBootstrap(IActionScheduler actionScheduler)
        {
            _actionScheduler = actionScheduler;
            //var defaultAction = new DefaultAction();
            //ActionScheduler = new EveActionScheduler(defaultAction, 60);
            //ActionScheduler.Schedule(new DScanAction());
        }

        private EveActionScheduler ActionScheduler { get; set; }

        public void HookToGameClient()
        {
            var onFrameEvent = LavishScript.Events.RegisterEvent("ISXEVE_onFrame");
            LavishScript.Events.AttachEventTarget(onFrameEvent, OnFrame);
        }

        private void OnFrame(object sender, LSEventArgs e)
        {
            ActionScheduler.Execute();
        }
    }
}