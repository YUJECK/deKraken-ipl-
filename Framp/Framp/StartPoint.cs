using System.Reflection;
using Framp.DI;
using Framp.Infrastructure.ServicesManagement;
using Framp.InputSystem;
using Framp.Tests;
using Framp.Windows;
using SFML.Graphics;

namespace Framp
{
    internal static class StartPoint
    {
        private static void Main()
        {
            InputService service = new();
            RegistryService registryService = new();
            GameLoop gameLoop = new(registryService);

            registryService.RegisterService(service);

            EntityMaster.SetContainer(registryService);

            EntityMaster.SpawnEntity(new TestEntity());
            EntityMaster.SpawnEntity(new StaticSprite());
            
            gameLoop.StartLoop();
        }
    }
}