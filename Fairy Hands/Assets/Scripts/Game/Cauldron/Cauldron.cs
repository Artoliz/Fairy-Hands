using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public Dictionary<Ingredient.Type, int> Ingredients = new Dictionary<Ingredient.Type, int>();

    public Material[] PotionVisuals = null;
    public GameObject[] Potions = null;

    public void AddIngredient(Ingredient.Type ingredient)
    {
        if (ingredient == Ingredient.Type.None)
        {
            // Bad Ingredient.
            return;
        }

        if (Ingredients[ingredient] == 0)
            Ingredients.Add(ingredient, 1);
        else
            Ingredients[ingredient] += 1;

        Debug.Log("Add ingredient: " + ingredient);
    }

    public void EmptyCauldron()
    {
        Ingredients.Clear();
    }

    public void CreateRecipe()
    {
        if (GameManager.Instance.IsRecipeExist(Ingredients))
        {
            GameObject potion = Instantiate(Potions[Random.Range(0, Potions.Length - 1)]);
            foreach (Transform child in potion.transform)
            {
                if (child.name == "Fill")
                {
                    child.GetComponent<Renderer>().material = PotionVisuals[Random.Range(0, PotionVisuals.Length - 1)];
                    break;
                }
            }
            Debug.Log("Recette créée! Jouer l'animation!");
        } else
        {
            Debug.Log("Recette foirée... Jouer l'animation!");
        }
        EmptyCauldron();
    }
}
