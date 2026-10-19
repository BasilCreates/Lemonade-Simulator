using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;


public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private List<InventorySlot> items = new List<InventorySlot>(); //creating a new list to populate BOUGHT items



    public List<InventorySlot> InventorySlots //public property to populate data and read PUBLICALLY, while setting it privately
    {
        get { return items; }
        private set { items = value; }
    }

    
    public void AddItem(Item item, int amountToAdd)
    {
        if (item == null || amountToAdd <= 0)
            return;

        InventorySlot existingSlot = items.Find(slot => slot.ItemName == item.Name);

        if (existingSlot != null)
        {
            existingSlot.AddQuantity(amountToAdd);

            Debug.Log(
                $"Added {amountToAdd} {item.Name}. " +
                $"New quantity: {existingSlot.ItemQuantity}"
            );
        }
        else
        {
            InventorySlot newSlot = new InventorySlot(
                item.Name,
                amountToAdd
            );

            items.Add(newSlot);

            Debug.Log(
                $"Added new item: {item.Name}. " +
                $"Quantity: {newSlot.ItemQuantity}"
            );
        }
    }
    public bool HasEnoughItems(string itemName, int amount)
    {
        if (amount <= 0)
            return false;

        InventorySlot matchingSlot = items.Find(slot => slot.ItemName == itemName);

        if (matchingSlot == null)
            return false;

        return matchingSlot.ItemQuantity >= amount;
    }

    public bool RemoveItems(string itemName, int amount)
    {
        if (amount <= 0)
            return false;

        InventorySlot matchingSlot = items.Find(
            slot => slot.ItemName == itemName
        );

        if (matchingSlot == null || matchingSlot.ItemQuantity < amount)
            return false;

        matchingSlot.RemoveQuantity(amount);

        if (matchingSlot.ItemQuantity == 0)
            items.Remove(matchingSlot);

        return true;
    }
}
