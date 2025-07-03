﻿using CookieCookbook.Recipes.Ingredients;

namespace CookieCookbook.Recipes;

public class Recipe
{
    public IEnumerable<Ingredient> Ingredients { get; }

    public Recipe(IEnumerable<Ingredient> ingredients)
    {
        Ingredients = ingredients;
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine,
            Ingredients.Select(ingredient => $"{ingredient.Name}. {ingredient.PreparationInstructions}"));
    }
}
