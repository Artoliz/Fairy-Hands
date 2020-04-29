using System;
using System.Collections.Generic;

public enum RecipeName
{
    Love,
    NightVision,
    Health,
    Fear,
    Explosion,
    Mobility,
    WerewolfMorphos,
    Strength,
    Invisibility,
    //UnderwaterBreathing,
    //Shield,
    //Revive
};

struct Recipe
{
    public RecipeName Name;
    public Dictionary<Ingredient.Type, int> Ingredients;
    public int Points;
};