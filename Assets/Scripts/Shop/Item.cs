
using UnityEngine;

public class Item
{
    private string name;
    private int Price;
    private int quantity;
    private Sprite Image;
    private Icategory itemCategory; //declaring our enum to get and store its value.

    public enum Icategory //this enum helps us create categories so we can separate the sections of the store!
    {
        Ingredient, Inventory, LemonadeStand
    }


    public Icategory ItemCategory //getting the information and setting it to Icategory. allowing variables to read it but not edit it themselves.
    {
        get { return itemCategory; }
        private set { itemCategory = value; }
    }

    public string Name //using a property to get the name but set it publically, read it publicly, so people can't just change the code
    {  get { return name; } 
       private set { name = value; }
    }   

    public int PriceTag //same process, duplicated here
    { 
        get { return Price; }
        private set { Price = value; } 
    }

    public Sprite ItemImage //same here
    {
        get { return Image; }
        private set { Image = value; }
    }

    public int ItemQuantity
    {
        get { return  quantity; }
        private set { quantity = value; }
    }

    public Item(string newName, int newPrice,  Sprite newImage, int newQuantity, Icategory newCategory) //setting a constructor with our "ingredients", and releasing it to the public basically. They then have to follow these exact parameters to create the item
    {
        Name = newName;
        PriceTag = newPrice;
        ItemImage = newImage;
        ItemQuantity = newQuantity;
        ItemCategory = newCategory; //now when making items, we can add the category we created.
    }

}
