using UnityEngine;

public class ShopMenuUI : MonoBehaviour //where we DISPLAY the entire row of shop ITEMS
{
    [SerializeField]
    private GameObject itemOptions;

    [SerializeField]
    private GameObject menuPanel; //use a master menu, shows different info, but the same overall shell





    [SerializeField]
    private ShopInventory inventory; //calling our shop inventory to get our data, to populate the UI.

    [SerializeField]
    private ShopItemUI itemUIPrefab; //plug in our prefab which has the shopItemUI script attached

    [SerializeField]
    private Transform contentParent; //grabbing the CONTENT parent, to make sure the prefab spawns as a child of it

    public void Awake()
    {
        itemOptions.SetActive(false);
        menuPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //an escape chain to get out of the menu. nice and easy.
        {
            if (itemOptions.activeSelf)
            {
                itemOptions.SetActive(false);
            }
            else if (menuPanel.activeSelf)
            {
                menuPanel.SetActive(false);
            }
        }
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
            }

        }
    }

    public void OpenShopMenu()
    {
        menuPanel.SetActive(true);
    }

    public void ShowIngredients()
    {
        menuPanel.SetActive(false);
        itemOptions.SetActive(true);
        CreateItemsList(Item.Icategory.Ingredient);
    }
    public void ShowInventory()
    {
        menuPanel.SetActive(false);
        itemOptions.SetActive(true);
        CreateItemsList(Item.Icategory.Inventory);
    }

    public void ShowStands()
    {
        menuPanel.SetActive(false);
        itemOptions.SetActive(true);
        CreateItemsList(Item.Icategory.LemonadeStand);
    }
}
