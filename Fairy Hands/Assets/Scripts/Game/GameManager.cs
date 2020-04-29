using System;
using System.Collections;
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

        // Health
        recipe.Name = RecipeName.Health;
        ingredients.Add(Ingredient.Type.Blood, 2);
        ingredients.Add(Ingredient.Type.Cherry, 2);
        ingredients.Add(Ingredient.Type.Butterfly, 1);
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // Love
        recipe.Name = RecipeName.Love;
        ingredients.Add(Ingredient.Type.Heart, 2);
        ingredients.Add(Ingredient.Type.Apple, 2);
        ingredients.Add(Ingredient.Type.Rose, 2);
        ingredients.Add(Ingredient.Type.Blood, 2);
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // WerewolfMorphos
        recipe.Name = RecipeName.WerewolfMorphos;
        ingredients.Add(Ingredient.Type.WolfPaw, 4);
        ingredients.Add(Ingredient.Type.Heart, 1);
        ingredients.Add(Ingredient.Type.EyeMushroom, 2);
        ingredients.Add(Ingredient.Type.Blood, 2);
        ingredients.Add(Ingredient.Type.Slime, 2);
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // Mobility
        recipe.Name = RecipeName.Mobility;
        ingredients.Add(Ingredient.Type.WolfPaw, 4);
        ingredients.Add(Ingredient.Type.Lemon, 2);
        ingredients.Add(Ingredient.Type.Feather, 1);
        ingredients.Add(Ingredient.Type.Water, 1);
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // Strength
        recipe.Name = RecipeName.Strength;
        ingredients.Add(Ingredient.Type.Watermelon, 1);
        ingredients.Add(Ingredient.Type.Golem, 1);
        ingredients.Add(Ingredient.Type.Water, 2);
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // NightVision
        recipe.Name = RecipeName.NightVision;
        ingredients.Add(Ingredient.Type.Eye, 2);
        ingredients.Add(Ingredient.Type.EyeMushroom, 2);
        ingredients.Add(Ingredient.Type.Bat, 2);
        ingredients.Add(Ingredient.Type.WolfPaw, 4);
        ingredients.Add(Ingredient.Type.Slime, 2);
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // Explosion
        recipe.Name = RecipeName.Explosion;
        ingredients.Add(Ingredient.Type.Chili, 3);
        ingredients.Add(Ingredient.Type.EyeMushroom, 2);
        ingredients.Add(Ingredient.Type.Water, 1);
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // Health
        recipe.Name = RecipeName.Health;
        ingredients.Add(Ingredient.Type.Blood, 2);
        ingredients.Add(Ingredient.Type.Cherry, 2);
        ingredients.Add(Ingredient.Type.Butterfly, 1);
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // Invisibility
        recipe.Name = RecipeName.Invisibility;
        ingredients.Add(Ingredient.Type.JellyFish, 3);
        ingredients.Add(Ingredient.Type.Lemon, 1);
        ingredients.Add(Ingredient.Type.Slime, 3);
        ingredients.Add(Ingredient.Type.Water, 3);
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // UnderwaterBreathing
        recipe.Name = RecipeName.UnderwaterBreathing;
        ingredients.Add(Ingredient.Type.Fish, 2);
        ingredients.Add(Ingredient.Type.JellyFish, 2);
        ingredients.Add(Ingredient.Type.Water, 2);
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // Shield
        recipe.Name = RecipeName.Shield;
        ingredients.Add(Ingredient.Type.Golem, 2);
        ingredients.Add(Ingredient.Type.Lemon, 1);
        ingredients.Add(Ingredient.Type.Water, 1);
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // Revive
        recipe.Name = RecipeName.Revive;
        ingredients.Add(Ingredient.Type.Heart, 1);
        ingredients.Add(Ingredient.Type.Blood, 3);
        ingredients.Add(Ingredient.Type.Cherry, 2);
        ingredients.Add(Ingredient.Type.Butterfly, 2);
        ingredients.Add(Ingredient.Type.EyeMushroom, 2);
        ingredients.Add(Ingredient.Type.Slime, 2);
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();
    }

    private void InitGameRecipes()
    {
        int nbRecipes = UnityEngine.Random.Range(4, 6);
        Array names = Enum.GetValues(typeof(RecipeName));

        while (GameRecipes.Count < nbRecipes)
        {
            int indexRecipe = UnityEngine.Random.Range(0, names.Length - 1);
            if (!GameRecipes.ContainsKey((RecipeName)indexRecipe))
                GameRecipes.Add((RecipeName)indexRecipe, new Pair<int, int>(0, UnityEngine.Random.Range(1, 3)));
        }

        if (Storage != null)
        {
            List<Ingredient.Type> used = new List<Ingredient.Type>();

            foreach (Recipe recipe in Recipes)
            {
                if (GameRecipes.ContainsKey(recipe.Name))
                {
                    foreach (Ingredient.Type ing in recipe.Ingredients.Keys)
                    {
                        if (!used.Contains(ing))
                            used.Add(ing);
                    }
                }
            }
            Storage.GenerateIngredientsGetter(used);
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
        Storage.StopGame();
        PlayerPoints = 0;
        StartCoroutine(Init());
    }

    IEnumerator Init()
    {
        yield return new WaitForSeconds(0.1f);
        InitGameRecipes();
        // Reset Timer
    }

    public void StopGame()
    {
        GameRecipes.Clear();
        Storage.StopGame();
        Book.CloseBook();
        PlayerPoints = 0;
        // Stop Timer
    }
}
