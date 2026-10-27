using System.Security.Cryptography;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField]
    private int startingMoney; //testing money the user will be starting with

    [SerializeField]
    private PlayerInventory playerInventory;

    [SerializeField]
    private int currentMoney;

    [SerializeField] 
    private MoneyUI moneyUI;


    private void Awake()
    {
        currentMoney = startingMoney; //binds the curernt money
    }

    public int CurrentMoney //publicly declaring it so that other scripts can SEE it but not set it. no 99999 dollar shenanigans
    {
        get { return currentMoney; }
        private set { currentMoney = value; } 
    }

    public void BuyItem(Item item) //the cash transaction AFTER you buy an item
    {
        if(item.PriceTag <= currentMoney) //compares if they can even afford it LMAOOO
        {
            currentMoney -= item.PriceTag; //runs the correct calculationsssss
            Debug.Log("Item " + item.Name + " Bought!");
            moneyUI.ShowMoney();
            playerInventory.AddItem(item, item.ItemQuantity); //calls playerInventory to set the items in ITS list too, so it shows on inventory
        }
    }


    public void ReceivePayment(int amount)
    {
        if (amount <= 0)
        {
            return;
        }

        CurrentMoney += amount;
        moneyUI.ShowMoney();
    }
}
