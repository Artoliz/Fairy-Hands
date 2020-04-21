﻿using UnityEngine;
using System.Collections;
using Valve.Newtonsoft.Json.Utilities;

public class DemoBookController : MonoBehaviour
{
    [Tooltip("Defines the pages of this book")]
    public GameObject[] UiPages; // The UI prefabs associated to each pages

    public AnimatedBookController bookController; // Reference to the BookController script

    public Sprite[] pageBackground;
    private int pageStyleIndex = 0;

    // Control book with Left / Right arrows
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            bookController.TurnToPreviousPage();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            bookController.TurnToNextPage();
        }
    }

    public void switchPageStyle()
    {
        pageStyleIndex++;
        if (pageStyleIndex >= pageBackground.Length)
        {
            pageStyleIndex = 0;
        }

        bookController.defaultBackground = pageBackground[pageStyleIndex];

        foreach (AnimatedBookController.PageObjects page in bookController.getPageObjects())
        {
            page.RectoImage.sprite = pageBackground[pageStyleIndex];
            page.VersoImage.sprite = pageBackground[pageStyleIndex];
        }
    }
}