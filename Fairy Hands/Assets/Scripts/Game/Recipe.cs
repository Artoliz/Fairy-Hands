using System;
using System.Collections.Generic;

public enum RecipeName
{
    Polynectare = 0,
    Heal = 1,
    Levitation = 2,
    Fear = 3,
    Nyctalope = 4,
    BreathingUnderwater = 5
};

struct Recipe
{
    public RecipeName Name;
    public Dictionary<Ingredient.Type, int> Ingredients;
    public int Points;
};