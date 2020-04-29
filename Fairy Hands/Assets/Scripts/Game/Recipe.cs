using System;
using System.Collections.Generic;

public enum RecipeName
{
    Health,
    Love,
    WerewolfMorphos,
    Mobility,
    Strength,
    NightVision,
    Fear,
    Explosion,
    Invisibility,
    UnderwaterBreathing,
    Shield,
    Revive
};

struct Recipe
{
    public RecipeName Name;
    public Dictionary<Ingredient.Type, int> Ingredients;
    public int Points;
};