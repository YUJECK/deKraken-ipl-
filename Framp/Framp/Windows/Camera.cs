using SFML.Graphics;
 using SFML.System;
 
 namespace Framp.Windows;
 
 public class Camera
 {
     public readonly View View;
 
     public Camera()
     {
         View = new View(new Vector2f(900, 900), new Vector2f(400, 400));
     }
 
     public void SetCameraPosition(Vector2f position)
         => View.Center = position;
 }