using LavishScriptAPI;

namespace ChewySuperstar.Main
{
    public class EVEBootstrap
    {
        public EVEBootstrap()
        {
            var defaultAction = new DefaultAction();
            ActionScheduler = new OnFrameScheduler(defaultAction, 60);
        }

        private OnFrameScheduler ActionScheduler { get; set; }

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