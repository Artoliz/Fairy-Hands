using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private List<Vector3> _positions = new List<Vector3>();

    private int _ingredientsOffset = 0;

    public GameObject[] Getters = null;

    private void Start()
    {
        foreach (Transform child in transform)
            _positions.Add(child.transform.localPosition);

        ShufflePositions();
    }

    private System.Random rng = new System.Random();

    public void ShufflePositions()
    {
        int n = _positions.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Vector3 value = _positions[k];
            _positions[k] = _positions[n];
            _positions[n] = value;
        }
    }

    public void GenerateIngredientsGetter(List<Ingredient.Type> ingredients)
    {
        foreach (GameObject getter in Getters)
        {
            foreach (Ingredient.Type ingredient in ingredients)
            {
                if (getter.name.Contains(ingredient.ToString()))
                {
                    GameObject tmp = Instantiate(getter);
                    tmp.transform.SetParent(transform);
                    tmp.transform.localPosition = _positions[_ingredientsOffset];
                    _ingredientsOffset += 1;
                }
            }
        }

        if (_ingredientsOffset >= _positions.Count)
            return;

        Array values = Enum.GetValues(typeof(Ingredient.Type));
        foreach (var value in values)
        {
            if (!ingredients.Contains((Ingredient.Type)value) && _ingredientsOffset < _positions.Count)
            {
                foreach (GameObject getter in Getters)
                {
                    if (getter.name.Contains(value.ToString()))
                    {
                        GameObject tmp = Instantiate(getter);
                        tmp.transform.SetParent(transform);
                        tmp.transform.localPosition = _positions[_ingredientsOffset];
                        tmp.transform.localScale /= 2;
                        _ingredientsOffset += 1;
                    }
                }
            }
        }
    }
}
