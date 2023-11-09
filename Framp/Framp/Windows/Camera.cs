using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Framp.Windows;
 
 public class Camera
 {
     private readonly View View;
     public float Size { get; private set; } = 1;
     public Vector2f Center => View.Center;

     public Camera(Vector2f center, float size)
     {
         View = new View(center, new Vector2f(VideoMode.DesktopMode.Width, VideoMode.DesktopMode.Height));
         View.Zoom(size);
     }
     
     public void SetCameraPosition(Vector2f position)
         => View.Center = position;
     
     public void SetCameraSize(float size)
     {
         if(size == Size)
             return;
         
         View.Zoom(-1);
     }
     
     public void ApplyViewToRenderWindow(RenderWindow renderWindow)
     {
        renderWindow.SetView(View);
     }
     
     public void SetViewSize(float width, float height)
     {
         View.Size = new Vector2f(width, height);
     }
 }