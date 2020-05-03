using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;
using Valve.Newtonsoft.Json.Utilities;

public class AutoBookController : MonoBehaviour
{
    [FormerlySerializedAs("UiPages")] [Tooltip("Defines the pages of this book")]
    public GameObject UiIntroTutoPage; // The UI prefabs associated to each tutorial pages

    public GameObject UiIntroRecipePage; // The UI prefabs associated to each tutorial pages

    public GameObject UiLastEmptyPage; // The UI prefabs associated to each tutorial pages

    public GameObject[] UiTutoPages; // The UI prefabs associated to each tutorial pages

    public GameObject[] UiRecipePages; // The UI prefabs associated to each recipes pages

    public AnimatedBookController bookController; // Reference to the BookController script

    public Sprite[] pageBackground;
    private int pageStyleIndex = 0;

    private Dictionary<RecipeName, Pair<int, int>> _gameRecipes;

    public void CreateBook(Dictionary<RecipeName, Pair<int, int>> gameRecipes, bool tutorial)
    {
        _gameRecipes = gameRecipes;

        bookController.Reset();
        int i = 0; 
        bookController.pagesUi.AddDistinct(new AnimatedBookController.Page());
        AnimatedBookController.Page page = bookController.pagesUi[0];


        if (tutorial)
        {
            i = addPageInBook(i, UiIntroTutoPage);

            foreach (var uiTutoPage in UiTutoPages)
            {
                i = addPageInBook(i, uiTutoPage);
            }

            i = addPageInBook(i, UiLastEmptyPage);
        }

        i = addPageInBook(i, UiIntroRecipePage);

        foreach (var gameRecipe in _gameRecipes)
        {
            var recipeName = gameRecipe.Key.ToString();

            foreach (var uiPage in UiRecipePages)
            {
                if (uiPage.name.Contains(recipeName))
                {
                    i = addPageInBook(i, uiPage);
                    break;
                }
            }
        }

        if (page.UiVerso == null)
        {
            page.UiVerso = UiLastEmptyPage;
        }

        bookController.OpenBook();
    }

    int addPageInBook(int pageIndex, GameObject uiPage)
    {
        if (pageIndex >= bookController.pagesUi.Count)
        {
            bookController.pagesUi.AddDistinct(new AnimatedBookController.Page());
        }
        
        AnimatedBookController.Page page = bookController.pagesUi[pageIndex];

        if (page.UiRecto == null)
        {
            page.UiRecto = uiPage;
        }
        else
        {
            page.UiVerso = uiPage;
            pageIndex++;
        }

        return pageIndex;
    }


    public void RecipeDone(RecipeName name)
    {
        foreach (var page in bookController.bookPages)
        {
            if (page.UiRecto.gameObject.name.Contains(name.ToString()))
            {
                page.UiRecto.GetComponentInChildren<AutoBookRecipeCounter>().SetDone(_gameRecipes[name].First);
                break;
            }
            else if (page.UiVerso.gameObject.name.Contains(name.ToString()))
            {
                page.UiVerso.GetComponentInChildren<AutoBookRecipeCounter>().SetDone(_gameRecipes[name].First);
                break;
            }
        }
    }

    public int GetToDoRecipe(string name)
    {
        foreach (var recipe in _gameRecipes)
        {
            string recipeName = recipe.Key.ToString();
            if (name.Contains(recipeName))
            {
                return recipe.Value.Second;
            }
        }

        return -1;
    }

    public int GetDoneRecipe(string name)
    {
        foreach (var recipe in _gameRecipes)
        {
            string recipeName = recipe.Key.ToString();
            if (name.Contains(recipeName))
            {
                return recipe.Value.First;
            }
        }

        return -1;
    }

    public void CloseBook()
    {
        bookController.CloseBook();
    }

// Control book with Left / Right arrows
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            bookController.TurnToPreviousPage();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            bookController.NextPage();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            bookController.PreviousPage();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            bookController.TurnToNextPage();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bookController.getBookState() == AnimatedBookController.BOOK_STATE.OPENED)
                bookController.CloseBook();
            else if (bookController.getBookState() == AnimatedBookController.BOOK_STATE.CLOSED)
                bookController.OpenBook();
        }
    }
}