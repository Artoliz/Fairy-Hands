using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Dictionary<Recipe, Dictionary<Ingredient.Type, int>> Recipes;

    private void Awake()
    {
        Instance = this;
    }

    public bool IsRecipeExist(Dictionary<Ingredient.Type, int> ingredients)
    {
        foreach (var recipe in Recipes.Keys)
        {
            var require = Recipes[recipe];
            if (AreIngredientsMatch(require, ingredients))
                return true;
        }
        return false;
    }

    private bool AreIngredientsMatch(Dictionary<Ingredient.Type, int> required, Dictionary<Ingredient.Type, int> given)
    {
        foreach (var requiredIngredient in required.Keys)
        {
            if (given[requiredIngredient] != required[requiredIngredient])
                return false;
        }
        return true;
    }
}
