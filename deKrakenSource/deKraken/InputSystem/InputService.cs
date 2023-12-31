﻿using SFML.Window;

namespace deKraken.InputSystem;

public class InputService : ITickable
{
    private static readonly Dictionary<int, int> KeysState = new();

    public InputService()
    {
        for(int key = 0; key <= 256; key++)
        {
            KeysState.Add(key, 0);
        }
    }

    public bool IsKeyPressed(Keyboard.Key key)
    {
        return Keyboard.IsKeyPressed(key);
    }
    
    public bool IsKeyDown(Keyboard.Key key)
    {
        return KeysState[(int)key] == 1;
    }

    public bool IsKeyUp(Keyboard.Key key)
    {
        return KeysState[(int)key] == -1;
    }
    
    public void Tick()
    {
        for(int key = 0; key <= 256; key++)
        {
            if (Keyboard.IsKeyPressed((Keyboard.Key)key))
            {
                KeysState[key] += 1;
            }
            else if(KeysState[key] == -1)
            {
                KeysState[key] = 0;
            }
            else if (KeysState[key] > 0)
            {
                KeysState[key] = -1;
            }
        }
    }
}