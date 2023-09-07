using Framp.Tests;
using SFML.Graphics;

namespace Framp
{
    class Initial
    {
        private static void Main()
        {
            var renderWindow = WindowWrapper.RenderWindow;

            EntityMaster entityMaster = new(new List<Entity>());
            entityMaster.AddEntity(new TestEntity());
            
            while (renderWindow.IsOpen)
            {
                renderWindow.DispatchEvents();
                renderWindow.Clear(Color.Black);
                
                entityMaster.UpdateEntities();
                
                renderWindow.Display();
            }
        }
    }
}