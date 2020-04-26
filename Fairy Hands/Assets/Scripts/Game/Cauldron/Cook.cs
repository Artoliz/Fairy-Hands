using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook : MonoBehaviour
{
    private Cauldron _cauldron = null;

    private void Start()
    {
        _cauldron = GetComponentInParent<Cauldron>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ingredient") && _cauldron != null)
        {
            _cauldron.AddIngredient(other.GetComponent<Ingredient>()._type);
        }
    }
}
