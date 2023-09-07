using Framp.Tests;
using SFML.Graphics;

namespace Framp
{
    internal class StartPoint
    {
        private static void Main()
        {
            var renderWindow = WindowWrapper.RenderWindow;

            EntityMaster.AddEntity(new TestEntity());
            
            while (renderWindow.IsOpen)
            {
                renderWindow.DispatchEvents();
                renderWindow.Clear(Color.Black);
                
                EntityMaster.UpdateEntities();
                
                renderWindow.Display();
            }
        }
    }
}