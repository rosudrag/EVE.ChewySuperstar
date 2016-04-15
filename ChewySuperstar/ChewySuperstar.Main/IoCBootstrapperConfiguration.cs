using DryIoc;

namespace ChewySuperstar.Main
{
    public static class IoCBootstrapperConfiguration
    {
        public static IContainer BootstrapIoCContainer()
        {
            var container = new Container();

            container.Register<IEVEBootstrap, EVEBootstrap>();
            container.Register<IActionScheduler, EveActionScheduler>();

            return container;
        }
    }
}