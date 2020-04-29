using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Cauldron : MonoBehaviour
{
    public Chest Chest;

    public Dictionary<Ingredient.Type, int> Ingredients = new Dictionary<Ingredient.Type, int>();

    public Material[] PotionVisuals = null;

    [SerializeField] private ParticleSystem BadPotion = null;
    [SerializeField] private ParticleSystem GoodPotion = null;

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

                    if (GoodPotion != null)
                    {
                        GoodPotion.gameObject.SetActive(true);
                        GoodPotion.Play();
                    }
                    else
                        Debug.Log("Couldn't play animation good");

                    Chest.SetPotion(emptyPotion);

                    break;
                }
            }
        } else
        {
            if (BadPotion != null)
            {
                BadPotion.gameObject.SetActive(true);
                BadPotion.Play();
            } else
                Debug.Log("Couldn't play animation bad");
        }
        EmptyCauldron();
    }
}
