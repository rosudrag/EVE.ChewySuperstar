using System;
using DryIoc;
using InnerSpaceAPI;
using LavishVMAPI;

namespace ChewySuperstar.Main
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            var container = BootstrapIoCContainer();

            Console.WriteLine("Hooking up to game client.");

            var gameBootstrapper = new EVEBootstrap();
            gameBootstrapper.HookToGameClient();

            Console.WriteLine("Game hook initialised.");
            Console.WriteLine("Press any key to terminate...");
            Console.ReadLine();

            InnerSpace.Echo("Program ended.");
        }

        private static IContainer BootstrapIoCContainer()
        {
            var container = new Container();

            return container;
        }
    }
}