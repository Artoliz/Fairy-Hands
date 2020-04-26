using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //private Dictionary<Recipe, Tuple<int, int>> GameRecipes = new Dictionary<Recipe, Tuple<int, int>>();

    //private Dictionary<Recipe, Dictionary<Ingredient.Type, int>> Recipes = new Dictionary<Recipe, Dictionary<Ingredient.Type, int>>();

    private List<Recipe> Recipes = new List<Recipe>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InitRecipes();
    }

    public bool IsRecipeExist(Dictionary<Ingredient.Type, int> ingredients)
    {
        //foreach (var recipe in Recipes.Keys)
        //{
        //    var require = Recipes[recipe];
        //    if (AreIngredientsMatch(require, ingredients))
        //        return true;
        //}
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

    private void InitRecipes()
    {
        Dictionary<Ingredient.Type, int> ingredients = new Dictionary<Ingredient.Type, int>();
        Recipe recipe = new Recipe();

        // Polynectare
        ingredients.Add(Ingredient.Type.Slime, 2);
        ingredients.Add(Ingredient.Type.Lemon, 1);
        ingredients.Add(Ingredient.Type.Blood, 1);
        recipe.Name = RecipeName.Polynectare;
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // Heal
        recipe = new Recipe();
        ingredients.Add(Ingredient.Type.Blood, 3);
        ingredients.Add(Ingredient.Type.Water, 2);
        ingredients.Add(Ingredient.Type.Watermelon, 1);
        recipe.Name = RecipeName.Heal;
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // Levitation
        recipe = new Recipe();
        ingredients.Add(Ingredient.Type.Feather, 4);
        ingredients.Add(Ingredient.Type.Bat, 2);
        ingredients.Add(Ingredient.Type.Water, 2);
        recipe.Name = RecipeName.Levitation;
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // Fear
        recipe = new Recipe();
        ingredients.Add(Ingredient.Type.Spider, 3);
        ingredients.Add(Ingredient.Type.Apple, 1);
        ingredients.Add(Ingredient.Type.Water, 2);
        recipe.Name = RecipeName.Fear;
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // BreathingUnderwater
        recipe = new Recipe();
        ingredients.Add(Ingredient.Type.Fish, 2);
        ingredients.Add(Ingredient.Type.Water, 2);
        ingredients.Add(Ingredient.Type.Frog, 2);
        recipe.Name = RecipeName.BreathingUnderwater;
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // Nyctalope
        recipe = new Recipe();
        ingredients.Add(Ingredient.Type.Eye, 5);
        ingredients.Add(Ingredient.Type.Bat, 1);
        ingredients.Add(Ingredient.Type.Blood, 3);
        recipe.Name = RecipeName.Nyctalope;
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();
    }
}
