using System;
using System.Collections.Generic;

enum RecipeName
{
    Polynectare,
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