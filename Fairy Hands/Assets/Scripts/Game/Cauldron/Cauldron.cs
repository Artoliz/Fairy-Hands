using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Cauldron : MonoBehaviour
{
    public Dictionary<Ingredient.Type, int> Ingredients = new Dictionary<Ingredient.Type, int>();

    public Material[] PotionVisuals = null;

    public void AddIngredient(Ingredient.Type ingredient)
    {
        if (ingredient == Ingredient.Type.None)
        {
            EmptyCauldron();
            return;
        }

        if (!Ingredients.ContainsKey(ingredient))
            Ingredients.Add(ingredient, 1);
        else
            Ingredients[ingredient] += 1;
    }

    public void EmptyCauldron()
    {
        Ingredients.Clear();
    }

    public void CreateRecipe(GameObject emptyPotion)
    {
        if (GameManager.Instance.IsRecipeExist(Ingredients))
        {
            foreach (Transform child in emptyPotion.transform)
            {
                if (child.name == "Fill")
                {
                    child.GetComponent<Renderer>().material = PotionVisuals[Random.Range(0, PotionVisuals.Length - 1)];

                    Debug.Log("Recette créée! Jouer l'animation!");

                    break;
                }
            }
        } else
        {
            Debug.Log("Recette foirée... Jouer l'animation!");
        }
        EmptyCauldron();
    }
}
