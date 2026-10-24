using UnityEngine;

public class ShopMenuUI : MonoBehaviour //where we DISPLAY the entire row of shop ITEMS
{
    [SerializeField]
    private GameObject itemOptions;

    [SerializeField]
    private GameObject menuPanel; //use a master menu, shows different info, but the same overall shell

    [SerializeField]
    private PlayerMoney playerMoney;

    [SerializeField]
    private ShopInventory inventory; //calling our shop inventory to get our data, to populate the UI.

    [SerializeField]
    private ShopItemUI itemUIPrefab; //plug in our prefab which has the shopItemUI script attached

    [SerializeField]
    private Transform contentParent; //grabbing the CONTENT parent, to make sure the prefab spawns as a child of it



    private void Update()
    {

    }


    public void CreateItemsList(Item.Icategory category)
    {
        foreach (Transform child in contentParent) //so when we switch categories, we don't see already existing items in the menu from other sections. it filters them out FIRST then creates the listed objects.
        {
            GameObject.Destroy(child.gameObject);
        }
        foreach (Item item in inventory.items) //for each item in our list we created in the shop inventory
        {
            if(category == item.ItemCategory) //if the name filters to the designated enums we created in the item class
            {
                ShopItemUI shopItemUI = Instantiate(itemUIPrefab, contentParent); //create a variable that takes the template, then PUTS our data into the listing, creating the new item
                shopItemUI.SetItem(item); //sets that item.
                shopItemUI.SetPlayerMoney(playerMoney); //give the reference of playermoney to the shopItemUI
            }

        }
    }

    public void OpenShopMenu() //Opens up the shop menu along with the seller texxt
    {
        menuPanel.SetActive(true);
    }

    public void ShowIngredients() //Showing the ingredients menu
    {
        menuPanel.SetActive(false);
        itemOptions.SetActive(true);
        CreateItemsList(Item.Icategory.Ingredient); //specifically load the ingredients menu
    }
    public void ShowInventory() //Show the inventory menu
    {
        menuPanel.SetActive(false);
        itemOptions.SetActive(true);
        CreateItemsList(Item.Icategory.Inventory); //specifically load the inventory menu
    }

    public void ShowStands() //Show the Stands Menu
    {
        menuPanel.SetActive(false);
        itemOptions.SetActive(true);
        CreateItemsList(Item.Icategory.LemonadeStand); //specifically load the lemonade stand menu
    }
}
