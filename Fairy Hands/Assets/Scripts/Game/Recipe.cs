using System;
using System.Collections.Generic;

enum RecipeName
{
    Polynectare = 0,
    Heal,
    Levitation,
    Fear,
    BreathingUnderwater,
    Nyctalope
};

struct Recipe
{
    public RecipeName Name;
    public Dictionary<Ingredient.Type, int> Ingredients;
};