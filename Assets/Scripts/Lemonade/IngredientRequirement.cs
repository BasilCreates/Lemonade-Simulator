using UnityEngine;

public class IngredientRequirement
{
    public string ItemName { get; private set; } //defining the requirement
    public int AmountPerServing { get; private set; }


    public IngredientRequirement(string itemName, int amountPerServing) //setting up using constructors to create ingredient requirement object
    {
        ItemName = itemName;
        AmountPerServing = amountPerServing;
    }
}
