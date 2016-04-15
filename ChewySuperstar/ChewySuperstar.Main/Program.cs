using System;
using DryIoc;
using InnerSpaceAPI;

namespace ChewySuperstar.Main
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            var container = IoCBootstrapperConfiguration.BootstrapIoCContainer();

            Console.WriteLine("Hooking up to game client.");

            var gameBootstrapper = container.Resolve<IEVEBootstrap>();
            gameBootstrapper.HookToGameClient();

            Console.WriteLine("Game hook initialised.");
            Console.WriteLine("Press any key to terminate...");
            Console.ReadLine();

            InnerSpace.Echo("Program ended.");
        }
    }
}