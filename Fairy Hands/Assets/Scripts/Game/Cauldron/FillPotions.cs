using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillPotions : MonoBehaviour
{
    private Cauldron _cauldron = null;

    private void Start()
    {
        _cauldron = GetComponentInParent<Cauldron>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Potion") && _cauldron != null)
        {
            foreach (Transform child in other.GetComponentInParent<BasicInteractions>().gameObject.transform)
            {
                if (child.name == "Fill" && child.GetComponent<Renderer>().material.name.Contains("Empty"))
                {
                    _cauldron.CreateRecipe(other.GetComponentInParent<BasicInteractions>().gameObject);
                    break;
                }
            }
        }
    }
}
