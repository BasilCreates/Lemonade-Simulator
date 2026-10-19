using UnityEngine;

public class InventorySlot
{
    private string itemName;
    private int itemQuantity; 


    public InventorySlot(string name, int quantity)
    {
        itemName = name;

        if (quantity < 0)
        {
            Debug.Log("Cannot add. Use a positive number");
            itemQuantity = 0;
            return;
        }
        itemQuantity = quantity;
    }

    public string ItemName
    {
        get { return itemName; }
        private set { itemName = value; }
    }

    public int ItemQuantity
    {
        get { return itemQuantity; }
        private set
        {
            if (value <= 0)
            {
                return;
            }
            itemQuantity = value; }
    }

    public void AddQuantity(int amount)
    {
        if (amount <= 0)
        {
            return;
        }
        ItemQuantity += amount;
    }

    public void RemoveQuantity(int amount)
    {
        if (amount <= 0 || amount > ItemQuantity)
            return;

        ItemQuantity -= amount;
    }
}

