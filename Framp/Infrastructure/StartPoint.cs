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

            ServicesRegistry servicesRegistry = new();
            servicesRegistry.RegisterService(service);
            
            EntityMaster.SetContainer(servicesRegistry);
            
            EntityMaster.AddEntity(new TestEntity());
            EntityMaster.AddEntity(new StaticSprite());
            
            WindowWrapper.SetCamera(new Camera());
            
            while (WindowWrapper.RenderWindow.IsOpen)
            {
                WindowWrapper.RenderWindow.DispatchEvents();
                WindowWrapper.RenderWindow.Clear(Color.Blue);
                
                EntityMaster.UpdateEntities();
                servicesRegistry.TickAll();
                
                WindowWrapper.RenderWindow.Display();
            }
        }
    }
}