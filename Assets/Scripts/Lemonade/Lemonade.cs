using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Search;
public class Lemonade //what our lemonade ACTUALLY IS, the ingredients put together
{

    private List<IngredientRequirement> ingredientRequirements = new List<IngredientRequirement>();


    private int pricePerServing = 2;

    public void AddRequirement(IngredientRequirement ingredientRequirement)
    {
        ingredientRequirements.Add(ingredientRequirement);
        Debug.Log("Added Ingredients required!");
    }

    public Lemonade()
    {
        AddRequirement(new IngredientRequirement("Lemon", 1));
        AddRequirement(new IngredientRequirement("Cups", 1));
        AddRequirement(new IngredientRequirement("Water Bottle", 1));
        AddRequirement(new IngredientRequirement("Sugar Cubes", 4));
    }

    public IReadOnlyList<IngredientRequirement> Requirements //an interface that exposes the list but does NOT let outside scripts alter it to however they want
    {
        get { return ingredientRequirements; }
    }

    public int PricePerServing
    {
       get { return pricePerServing; }
       private set { pricePerServing = value; }
    }   

}
