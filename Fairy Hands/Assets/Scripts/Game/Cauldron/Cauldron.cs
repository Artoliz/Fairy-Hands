using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Cauldron : MonoBehaviour
{
    public static Cauldron Instance;

    public Chest Chest;

    public Dictionary<Ingredient.Type, int> Ingredients = new Dictionary<Ingredient.Type, int>();

    public Material[] PotionVisuals = null;

    [SerializeField] private ParticleSystem BadPotion = null;
    [SerializeField] private ParticleSystem GoodPotion = null;

    [SerializeField] private AudioSource AudioGlassBreaking = null;
    [SerializeField] private AudioSource AudioCauldronFilled = null;
    [SerializeField] private AudioSource AudioPotionSuccess = null;

    private void Awake()
    {
        Instance = this;
    }

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
        AudioCauldronFilled.Play();
    }

    public void EmptyCauldron()
    {
        Ingredients.Clear();
    }

    public void CreateRecipe(GameObject emptyPotion)
    {
        Pair<string, string> recipe = GameManager.Instance.IsRecipeExist(Ingredients);
        if (recipe != null)
        {
            if (!emptyPotion.name.Contains(recipe.Second))
            {
                AudioGlassBreaking.Play();
                return;
            }
            foreach (Transform child in emptyPotion.transform)
            {
                if (child.name == "Fill")
                {
                    foreach (Material visual in PotionVisuals)
                    {
                        if (visual.name.Contains(recipe.First))
                        {
                            child.GetComponent<Renderer>().material = visual;
                            break;
                        }
                    }

                    AudioPotionSuccess.Play();

                    if (GoodPotion != null)
                    {
                        GoodPotion.gameObject.SetActive(true);
                        GoodPotion.Play();
                    }

                    break;
                }
            }
        }
        else
        {
            AudioGlassBreaking.Play();
            if (BadPotion != null)
            {
                BadPotion.gameObject.SetActive(true);
                BadPotion.Play();
            }
            foreach (Hand hand in Player.instance.hands)
            {
                foreach (var objects in hand.AttachedObjects)
                {
                    if (objects.attachedObject == emptyPotion)
                    {
                        hand.DetachObject(objects.attachedObject);
                        break;
                    }
                }
            }
        }
        EmptyCauldron();
    }
}
