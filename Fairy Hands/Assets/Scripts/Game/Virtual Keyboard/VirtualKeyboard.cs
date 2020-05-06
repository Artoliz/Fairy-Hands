using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualKeyboard : MonoBehaviour
{
    private string String = "";

    private bool CanPress = true;

    public void KeyPressed(string key)
    {
        if (CanPress)
        {
            String += key;
        }
    }

    public void EraseLastKey()
    {
        String = String.Remove(String.Length - 1, 1);
    }

    public void ClearString()
    {
        String = "";
    }

    public string GetString()
    {
        return String;
    }
}
