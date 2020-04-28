using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int PlayerPoints = 0;

    private List<Recipe> Recipes = new List<Recipe>();

    private Dictionary<RecipeName, Pair<int, int>> GameRecipes = new Dictionary<RecipeName, Pair<int, int>>();

    [SerializeField] private AutoBookController Book = null;
    [SerializeField] private Storage Storage = null;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InitRecipes();
    }

    private bool AreIngredientsMatch(Dictionary<Ingredient.Type, int> required, Dictionary<Ingredient.Type, int> given)
    {
        foreach (var givenIngredients in given.Keys)
        {
            if (!required.ContainsKey(givenIngredients) || required[givenIngredients] != given[givenIngredients])
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
        ingredients.Add(Ingredient.Type.Water, 1);
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
        ingredients.Add(Ingredient.Type.Eye, 4);
        ingredients.Add(Ingredient.Type.Bat, 2);
        ingredients.Add(Ingredient.Type.Blood, 1);
        recipe.Name = RecipeName.Nyctalope;
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();
    }

    private void InitGameRecipes()
    {
        int nbRecipe = UnityEngine.Random.Range(4, 6);

        for (int i = 0; i < nbRecipe; i++)
        {
            int indexRecipe = UnityEngine.Random.Range(0, 5);
            if (GameRecipes.ContainsKey((RecipeName)indexRecipe))
                i -= 1;
            else
                GameRecipes.Add((RecipeName)indexRecipe, new Pair<int, int>(0, UnityEngine.Random.Range(1, 3)));
        }

        if (Storage != null)
        {
            List<Ingredient.Type> types = new List<Ingredient.Type>();

            foreach (Recipe recipe in Recipes)
            {
                if (GameRecipes.ContainsKey(recipe.Name))
                {
                    foreach (Ingredient.Type ing in recipe.Ingredients.Keys)
                    {
                        if (!types.Contains(ing))
                            types.Add(ing);
                    }
                }
            }
            Storage.GenerateIngredientsGetter(types);
        }

        if (Book != null)
            Book.CreateBook(GameRecipes);
    }

    private void CheckIfAllRecipesAreDone()
    {
        int nbDone = 0;

        foreach (var value in GameRecipes.Values)
        {
            if (value.First == value.Second)
                nbDone += 1;
        }

        if (nbDone == GameRecipes.Count)
        {
            Debug.Log("Le jeu est fini: Toutes les recettes sont faites!");
        }
    }

    public bool IsRecipeExist(Dictionary<Ingredient.Type, int> ingredients)
    {
        foreach (var recipe in Recipes)
        {
            if (AreIngredientsMatch(recipe.Ingredients, ingredients) && GameRecipes[recipe.Name] != null && GameRecipes[recipe.Name].First < GameRecipes[recipe.Name].Second)
            {
                GameRecipes[recipe.Name].First += 1;
                PlayerPoints += recipe.Points;

                if (Book != null)
                    Book.RecipeDone(recipe.Name);

                CheckIfAllRecipesAreDone();
                return true;
            }
        }
        return false;
    }

    public void StartGame()
    {
        InitGameRecipes();
        PlayerPoints = 0;
        // Start Timer
    }

    public void RestartGame()
    {
        Book.CloseBook();
        GameRecipes.Clear();
        PlayerPoints = 0;
        InitGameRecipes();
        // Reset Timer
    }

    public void StopGame()
    {
        GameRecipes.Clear();
        Book.CloseBook();
        PlayerPoints = 0;
        // Stop Timer
    }
}
