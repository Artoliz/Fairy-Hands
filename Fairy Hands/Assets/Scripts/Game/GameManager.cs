using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int PlayerPoints = 0;

    private float seconds = 0;
    private float minutes = 0;
    private float hours = 0;

    private bool GameStarted = false;

    private ScoreList ScoreList;

    private List<Recipe> Recipes = new List<Recipe>();

    private Dictionary<RecipeName, Pair<int, int>> GameRecipes = new Dictionary<RecipeName, Pair<int, int>>();

    [SerializeField] private AutoBookController Book = null;
    [SerializeField] private TextMeshPro TimerText = null;
    [SerializeField] private Scores Scores = null;

    private void Awake()
    {
        Instance = this;

        ScoreList = new ScoreList();

        LoadScores();
    }

    private void Start()
    {
        InitRecipes();
    }

    private void Update()
    {

        if (GameStarted)
            UpdateTimer();
    }

    private void UpdateTimer()
    {
        seconds += Time.deltaTime;
        TimerText.text = minutes.ToString("00") + ":" + ((int)seconds).ToString("00");
        if (seconds >= 60)
        {
            minutes++;
            seconds = 0;
        }
        else if (minutes >= 60)
        {
            hours++;
            minutes = 0;
        }
    }

    private void SaveScore(string time, int points)
    {
        if (!Directory.Exists(Path.Combine(Application.persistentDataPath, "Scores")))
            Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "Scores"));

        Score Sc = new Score();
        Sc.Time = time;
        Sc.Points = points;

        ScoreList.Scores.Add(Sc);
        Scores.SetScores(ScoreList.Scores);

        var path = Path.Combine(Application.persistentDataPath, "Scores", "Scores.json");
        //Debug.Log(JsonUtility.ToJson(ScoreList, true));
        File.WriteAllText(path, JsonUtility.ToJson(ScoreList, true));
    }

    private void LoadScores()
    {
        string path = Path.Combine(Application.persistentDataPath, "Scores", "Scores.json");

        if (File.Exists(path))
        {
            ScoreList = JsonUtility.FromJson<ScoreList>(File.ReadAllText(path));
            Scores.SetScores(ScoreList.Scores);
        }
    }

    private void InitRecipes()
    {
        Dictionary<Ingredient.Type, int> ingredients = new Dictionary<Ingredient.Type, int>();
        Recipe recipe = new Recipe();

        // Health
        recipe.Name = RecipeName.Health;
        recipe.Points = 11;
        recipe.FlaskName = "Pyramide";
        ingredients.Add(Ingredient.Type.Blood, 2);
        ingredients.Add(Ingredient.Type.Cherry, 2);
        ingredients.Add(Ingredient.Type.Butterfly, 1);
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // Love
        recipe.Name = RecipeName.Love;
        recipe.Points = 14;
        recipe.FlaskName = "Sphere";
        ingredients.Add(Ingredient.Type.Heart, 2);
        ingredients.Add(Ingredient.Type.Apple, 2);
        ingredients.Add(Ingredient.Type.Rose, 2);
        ingredients.Add(Ingredient.Type.Blood, 2);
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // WerewolfMorphos
        recipe.Name = RecipeName.WerewolfMorphos;
        recipe.Points = 17;
        recipe.FlaskName = "Line";
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
        recipe.Points = 18;
        recipe.FlaskName = "Triangle";
        ingredients.Add(Ingredient.Type.WolfPaw, 4);
        ingredients.Add(Ingredient.Type.Lemon, 2);
        ingredients.Add(Ingredient.Type.Feather, 1);
        ingredients.Add(Ingredient.Type.Water, 1);
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // Strength
        recipe.Name = RecipeName.Strength;
        recipe.Points = 19;
        recipe.FlaskName = "Square";
        ingredients.Add(Ingredient.Type.Watermelon, 1);
        ingredients.Add(Ingredient.Type.Golem, 1);
        ingredients.Add(Ingredient.Type.Water, 2);
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // NightVision
        recipe.Name = RecipeName.NightVision;
        recipe.Points = 21;
        recipe.FlaskName = "Triangle";
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
        recipe.Points = 22;
        recipe.FlaskName = "Sphere";
        ingredients.Add(Ingredient.Type.Chili, 3);
        ingredients.Add(Ingredient.Type.EyeMushroom, 2);
        ingredients.Add(Ingredient.Type.Water, 1);
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // Fear
        recipe.Name = RecipeName.Fear;
        recipe.Points = 21;
        recipe.FlaskName = "Line";
        ingredients.Add(Ingredient.Type.Spider, 1);
        ingredients.Add(Ingredient.Type.EyeMushroom, 2);
        ingredients.Add(Ingredient.Type.Frog, 2);
        ingredients.Add(Ingredient.Type.Slime, 2);
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // Invisibility
        recipe.Name = RecipeName.Invisibility;
        recipe.Points = 24;
        recipe.FlaskName = "Line";
        ingredients.Add(Ingredient.Type.JellyFish, 3);
        ingredients.Add(Ingredient.Type.Lemon, 1);
        ingredients.Add(Ingredient.Type.Slime, 3);
        ingredients.Add(Ingredient.Type.Water, 3);
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // UnderwaterBreathing
        recipe.Name = RecipeName.UnderwaterBreathing;
        recipe.Points = 24;
        recipe.FlaskName = "Triangle";
        ingredients.Add(Ingredient.Type.Fish, 2);
        ingredients.Add(Ingredient.Type.JellyFish, 2);
        ingredients.Add(Ingredient.Type.Water, 2);
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // Shield
        recipe.Name = RecipeName.Shield;
        recipe.Points = 25;
        recipe.FlaskName = "Square";
        ingredients.Add(Ingredient.Type.Golem, 2);
        ingredients.Add(Ingredient.Type.Lemon, 1);
        ingredients.Add(Ingredient.Type.Water, 1);
        recipe.Ingredients = new Dictionary<Ingredient.Type, int>(ingredients);
        Recipes.Add(recipe);
        ingredients.Clear();

        // Revive
        recipe.Name = RecipeName.Revive;
        recipe.Points = 28;
        recipe.FlaskName = "Pyramide";
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

    private void InitGameRecipes(bool isTuto)
    {
        int nbRecipes = UnityEngine.Random.Range(4, 6);
        Array names = Enum.GetValues(typeof(RecipeName));

        int i = 0;
        while (GameRecipes.Count < nbRecipes)
        {
            int indexRecipe = UnityEngine.Random.Range(0, names.Length - 1);
            if (!GameRecipes.ContainsKey((RecipeName)indexRecipe))
                GameRecipes.Add((RecipeName)indexRecipe, new Pair<int, int>(0, UnityEngine.Random.Range(1, 2)));
            i += 1;
        }

        if (Book != null)
            Book.CreateBook(GameRecipes, isTuto);
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
            Book.CloseBook();

            SaveScore(minutes.ToString("00") + ":" + seconds.ToString("00"), PlayerPoints);

            GameStarted = false;
            Menu.Instance.BackToMainMenu();
        }
    }

    private bool AreIngredientsMatch(Dictionary<Ingredient.Type, int> requireds, Dictionary<Ingredient.Type, int> givens)
    {
        if (requireds.Count != givens.Count)
            return false;
        foreach (var required in requireds.Keys)
        {
            if (!givens.ContainsKey(required) || requireds[required] != givens[required])
                return false;
        }
        return true;
    }

    public Pair<string, string> IsRecipeExist(Dictionary<Ingredient.Type, int> ingredients)
    {
        if (ingredients.Count == 0)
            return null;

        foreach (var recipe in Recipes)
        {
            if (GameRecipes.ContainsKey(recipe.Name) && AreIngredientsMatch(recipe.Ingredients, ingredients) &&  GameRecipes[recipe.Name].First < GameRecipes[recipe.Name].Second)
            {
                GameRecipes[recipe.Name].First += 1;
                PlayerPoints += recipe.Points;

                if (Book != null)
                    Book.RecipeDone(recipe.Name);

                CheckIfAllRecipesAreDone();
                return new Pair<string, string>(recipe.Name.ToString(), recipe.FlaskName);
            }
        }
        return null;
    }

    public void StartGame(bool isTuto)
    {
        GameRecipes.Clear();
        Cauldron.Instance.EmptyCauldron();
        PlayerPoints = 0;
        seconds = 0;
        minutes = 0;
        hours = 0;
        GameStarted = true;
        InitGameRecipes(isTuto);
    }

    public void RestartGame()
    {
        Book.CloseBook();
        GameRecipes.Clear();
        Cauldron.Instance.EmptyCauldron();
        PlayerPoints = 0;
        seconds = 0;
        minutes = 0;
        hours = 0;
        GameStarted = true;
        InitGameRecipes(false);
    }

    public void StopGame()
    {
        GameRecipes.Clear();
        Book.CloseBook();
        Cauldron.Instance.EmptyCauldron();
        PlayerPoints = 0;
        seconds = 0;
        minutes = 0;
        hours = 0;
        GameStarted = false;
    }
}
