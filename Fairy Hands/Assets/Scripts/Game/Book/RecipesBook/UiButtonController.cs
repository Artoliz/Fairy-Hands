using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiButtonController : MonoBehaviour
{

    public GameObject leftButton;
    public GameObject rightButton;

    void Awake()
    {
        leftButton.SetActive(false);
        rightButton.SetActive(false);
    }
    
    public void ActivateLeftButton()
    {
        leftButton.SetActive(true);
        rightButton.SetActive(false);
    }
    
    public void ActivateRightButton()
    {
        leftButton.SetActive(false);
        rightButton.SetActive(true);
    }
}
