using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopInventory : MonoBehaviour
{
    public Sprite cupImage;
    public Sprite lemonImage;
    public Sprite sugarCubeImage;
    public Sprite waterBottleImage;

    public Sprite lemonadeStandImage;

    public Sprite woodCrateInventory;
    public Sprite wagonInventory;
    public Sprite miniFridgeInventory;

    [SerializeField]
    public List<Item> items = new List<Item>();


    public void Awake()
    {
        CreateItem(); //creates our item once on Awake.
    }


    public void Update()
    {

    }


    public void CreateItem()
    {
        Item Cups = new Item("Cups", 5, cupImage, 50, Item.Icategory.Ingredient);
        Item lemon = new Item("lemon", 5, lemonImage, 5, Item.Icategory.Ingredient); //lemon is created from our item class script
        Item sugarCubes = new Item("Sugar Cubes", 5, sugarCubeImage, 10, Item.Icategory.Ingredient);
        Item waterBottle = new Item("Water Bottle", 5, waterBottleImage, 5, Item.Icategory.Ingredient);
        items.Add(lemon); //adds lemon to our list 
        items.Add(Cups); //adds cups to our list 
        items.Add(sugarCubes); //adds sugar cubes to our list 
        items.Add(waterBottle); //adds water bottles to our list 

        Item lemonadeStand1 = new Item("Lemonade Stand 1", 8, lemonImage, 1, Item.Icategory.LemonadeStand);
        Item woodcrateInventory = new Item("Wood Crate Inventory", 10, woodCrateInventory, 1, Item.Icategory.Inventory);
        Item wagonnInventory = new Item("Wagon Inventory", 20, wagonInventory, 1, Item.Icategory.Inventory);
        Item minifridgeInventory = new Item("Mini Fridge Inventory", 100, miniFridgeInventory, 1, Item.Icategory.Inventory);
        items.Add(lemonadeStand1);
        items.Add(woodcrateInventory);
        items.Add(wagonnInventory);
        items.Add(minifridgeInventory);


        Debug.Log("Populating the list!");
    }
}
