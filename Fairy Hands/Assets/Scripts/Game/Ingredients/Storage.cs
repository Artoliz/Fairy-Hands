using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private List<Vector3> _positions = new List<Vector3>();

    private int _ingredientsOffset = 0;

    public List<GameObject> _ingredientsObj = new List<GameObject>();

    public GameObject[] Getters = null;

    private void Awake()
    {
        foreach (Transform child in transform)
            _positions.Add(child.position);

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
        List<Ingredient.Type> instantiates = new List<Ingredient.Type>();

        foreach (GameObject getter in Getters)
        {
            foreach (Ingredient.Type ingredient in ingredients)
            {
                if (getter.name.Contains(ingredient.ToString()) && !instantiates.Contains(ingredient))
                {
                    GameObject tmp = Instantiate(getter);
                    tmp.transform.SetParent(transform);
                    tmp.transform.position = _positions[_ingredientsOffset];
                    _ingredientsOffset += 1;
                    _ingredientsObj.Add(tmp);
                    instantiates.Add(ingredient);
                    if (_ingredientsOffset >= _positions.Count)
                        return;
                    break;
                }
            }
        }

        Array ings = Enum.GetValues(typeof(Ingredient.Type));
        foreach (var ing in ings)
        {
            if (instantiates.Contains((Ingredient.Type)ing))
                continue;
            foreach (GameObject getter in Getters)
            {
                if (getter.name.Contains(ing.ToString()))
                {
                    GameObject tmp = Instantiate(getter);
                    tmp.transform.SetParent(transform);
                    tmp.transform.position = _positions[_ingredientsOffset];
                    _ingredientsOffset += 1;
                    _ingredientsObj.Add(tmp);
                    if (_ingredientsOffset >= _positions.Count)
                        return;
                    break;
                }
            }
        }
    }

    public void StopGame()
    {
        foreach (var ing in _ingredientsObj)
            Destroy(ing);
        _ingredientsObj.Clear();
        _ingredientsOffset = 0;
    }
}
