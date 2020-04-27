using System;
using System.Collections.Generic;

enum RecipeName
{
    Polynectare = 0,
    Heal,
    Levitation,
    Fear,
    Nyctalope,
    BreathingUnderwater
};

struct Recipe
{
    public RecipeName Name;
    public Dictionary<Ingredient.Type, int> Ingredients;
};