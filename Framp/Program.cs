using Framp.Tests;
using SFML.Graphics;
using SFML.Window;

namespace Framp
{
    class Initial
    {
        private static void Main()
        {
            RenderWindow renderWindow = new(new VideoMode(250, 250), "Framp", Styles.Default);

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