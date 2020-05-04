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
            if (GameManager.Instance)
                GameManager.Instance.Name.text = String;
        }
    }

    public void EraseLastKey()
    {
        String.Remove(String.Length - 1);
        if (GameManager.Instance)
            GameManager.Instance.Name.text = String;
    }

    public void ClearString()
    {
        String = "";
        if (GameManager.Instance)
            GameManager.Instance.Name.text = String;
    }

    public string GetString()
    {
        return String;
    }
}
