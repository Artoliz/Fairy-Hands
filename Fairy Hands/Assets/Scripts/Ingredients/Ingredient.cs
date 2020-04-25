using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public enum StateIngredient
    {
        None,
        InHand,
        OverBoard
    }

    public StateIngredient State = StateIngredient.None;
}
