using Framp.Tests;
using Framp.Windows;
using SFML.Graphics;

namespace Framp
{
    internal static class StartPoint
    {
        private static void Main()
        {
            EntityMaster.AddEntity(new TestEntity());
            EntityMaster.AddEntity(new StaticSprite());
            
            WindowWrapper.SetCamera(new Camera());
            
            while (WindowWrapper.RenderWindow.IsOpen)
            {
                WindowWrapper.RenderWindow.DispatchEvents();
                WindowWrapper.RenderWindow.Clear(Color.Blue);
                
                EntityMaster.UpdateEntities();
                
                WindowWrapper.RenderWindow.Display();
            }
        }
    }
}