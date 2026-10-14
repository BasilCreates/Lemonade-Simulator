using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;


public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private List<Item> items = new List<Item>(); //creating a new list to populate BOUGHT items



    public List<Item> Items //public property to populate data and read PUBLICALLY, while setting it privately
    {
        get { return items; }
        private set { items = value; }
    }

    public void AddItem(Item item)
    {
        // Literally looking for an item with the same name using Find(), useful c# method
        Item existingItem = items.Find(existingItem => existingItem.Name == item.Name);

        if (existingItem != null)
        {
            // Item already exists: increase its quantity
            existingItem.AddQuantity(item.ItemQuantity);
            Debug.Log("Added more " + item.Name +
                      ". New quantity: " + existingItem.ItemQuantity);
        }
        else
        {
            // Item doesn't exist: create a new inventory slot
            items.Add(item);
            Debug.Log("Added new item: " + item.Name +
                      ". Quantity: " + item.ItemQuantity);
        }
    }

    public bool HasEnoughItems(string itemName, int amount)
    {
        Item matchingItem = items.Find(item => item.Name == itemName); //we find our item by grabbing our item Name in the inventory and adding it to itemName
        if (matchingItem == null)
        {
            return false;
        }

        return matchingItem.ItemQuantity >= amount;
    }

    public bool RemoveItems(string itemName, int amount)
    {
        if (amount < 0)
        {
            return false;
        }
        Item matchingItem = items.Find(item => item.Name == itemName);

        if (matchingItem == null || matchingItem.ItemQuantity < 0)
        {
            return false;
        }

        matchingItem.RemoveQuantity(amount);
        return true;
    }
}
