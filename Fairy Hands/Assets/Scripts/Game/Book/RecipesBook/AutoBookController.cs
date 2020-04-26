using UnityEngine;
using System.Collections;
using Valve.Newtonsoft.Json.Utilities;

public class AutoBookController : MonoBehaviour
{
    [Tooltip("Defines the pages of this book")]
    public GameObject[] UiPages; // The UI prefabs associated to each pages

    public AnimatedBookController bookController; // Reference to the BookController script

    public Sprite[] pageBackground;
    private int pageStyleIndex = 0;

    // Init pages at Start
    void Awake()
    {

        int i = 0;
        bookController.pagesUi.AddDistinct(new AnimatedBookController.Page());
        AnimatedBookController.Page page = bookController.pagesUi[0];
        
        foreach (var uiPage in UiPages) {

            if (i >= bookController.pagesUi.Count) {
                bookController.pagesUi.AddDistinct(new AnimatedBookController.Page());
                page = bookController.pagesUi[i];
            }
            
            if (page.UiRecto == null) {
                page.UiRecto = uiPage;
            } else {
                page.UiVerso = uiPage;
                i++;
            }
        }
    }

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