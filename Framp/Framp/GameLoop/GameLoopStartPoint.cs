using System.Reflection;
using Framp.DI;
using Framp.Infrastructure.ServicesManagement;
using Framp.InputSystem;
using Framp.Windows;
using SFML.Graphics;

namespace Framp
{
    internal static class GameLoopStartPoint
    {
        private const string GameStartMethod = "OnStart";
        
        private static void Main()
        {
            InputService inputService = new();
            ServicesRegistry servicesRegistry = new();
            GameLoop gameLoop = new(servicesRegistry);

            servicesRegistry.RegisterService(inputService);
            
            gameLoop.StartLoop(InvokeGameStartPoint);
        }

        private static void InvokeGameStartPoint()
        {
            GameStartPoint gameStartPoint = new();
            
            typeof(GameStartPoint)
                .GetMethod(GameStartMethod, BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(gameStartPoint, Array.Empty<object>());
        }
    }
}