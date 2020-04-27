using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class Pointer : MonoBehaviour
{
    public SteamVR_LaserPointer _pointerLeft;
    public SteamVR_LaserPointer _pointerRight;

    void Awake()
    {
        _pointerLeft.PointerIn += PointerInside;
        _pointerLeft.PointerOut += PointerOutside;
        _pointerLeft.PointerClick += PointerClick;

        _pointerRight.PointerIn += PointerInside;
        _pointerRight.PointerOut += PointerOutside;
        _pointerRight.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name.Contains("CubeButton"))
        {
            Button button = e.target.GetComponentInParent<Button>();
            if (button)
                button.onClick.Invoke();
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.name.Contains("CubeButton"))
        {
            SteamVR_LaserPointer pointer = (SteamVR_LaserPointer)sender;
            if (pointer)
                pointer.thickness = 0.002f;
            Button button = e.target.GetComponentInParent<Button>();
            if (button)
                button.Select();
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.name.Contains("CubeButton"))
        {
            SteamVR_LaserPointer pointer = (SteamVR_LaserPointer)sender;
            if (pointer)
                pointer.thickness = 0f;
            Button button = e.target.GetComponentInParent<Button>();
            if (button)
                EventSystem.current.SetSelectedGameObject(null);
        }
    }
}
