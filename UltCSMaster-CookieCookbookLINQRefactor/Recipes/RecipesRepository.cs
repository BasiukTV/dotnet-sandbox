﻿using CookieCookbook.DataAccess;
using CookieCookbook.Recipes.Ingredients;

namespace CookieCookbook.Recipes;

public class RecipesRepository : IRecipesRepository
{
    private readonly IStringsRepository _stringsRepository;
    private readonly IIngredientsRegister _ingredientsRegister;
    private const string Separator = ",";

    public RecipesRepository(
        IStringsRepository stringsRepository,
        IIngredientsRegister ingredientsRegister)
    {
        _stringsRepository = stringsRepository;
        _ingredientsRegister = ingredientsRegister;
    }

    public List<Recipe> Read(string filePath)
    {
        return _stringsRepository.Read(filePath).Select(RecipeFromString).ToList();
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        return new Recipe(recipeFromFile.Split(Separator).Select(int.Parse).Select(_ingredientsRegister.GetById).ToList());
    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {
        var recipesAsStrings = allRecipes
            .Select(recipe => string.Join(Separator, recipe.Ingredients.Select(ingredient => ingredient.Id)))
            .ToList();

        _stringsRepository.Write(filePath, recipesAsStrings);
    }
}
