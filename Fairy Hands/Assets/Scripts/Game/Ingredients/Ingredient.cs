using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public enum State
    {
        None,
        InHand,
        OverBoard
    }

    public enum Type
    {
        None,
        Apple,
        Bat,
        Lemon,
        Watermelon,
        Eye,
        Water,
        Blood,
        Slime,
        Feather,
        Fish,
        Frog,
        Spider,
        Tooth
    }

    public State _state = State.None;
    public Type _type = Type.None;
}
