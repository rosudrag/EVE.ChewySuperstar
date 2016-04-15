using LavishScriptAPI;

namespace ChewySuperstar.Main
{
    public interface IAttachToGameFrameBootstrapper
    {
        void HookToGameClient();
    }

    public class EVEBootstrap : IAttachToGameFrameBootstrapper
    {
        public EVEBootstrap()
        {
            //var defaultAction = new DefaultAction();
            //ActionScheduler = new OnFrameScheduler(defaultAction, 60);
            //ActionScheduler.Schedule(new DScanAction());
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