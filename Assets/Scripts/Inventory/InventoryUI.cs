using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryPanel; //ref to inventory panel

    [SerializeField]
    private PlayerInventory playerInventory;

    [SerializeField]
    private InventoryUIPrefab inventoryUIPrefab;

    [SerializeField]
    private Transform contentParent;

    private void Awake()
    {
        inventoryPanel.SetActive(false); //keep it off until needed
    }

    public void Update()
    {
        OpenInventoryPanel();
    }

    public void OpenInventoryPanel()
    {
        if (Input.GetKeyDown(KeyCode.I)) //press i, it checks if its active, if not it turns on, if it is it turns it off.
        {
            if (inventoryPanel.activeSelf)
            {
                inventoryPanel.SetActive(false);
            }
            else
            {
                inventoryPanel.SetActive(true);
                CreateItemsList(); //we forgot to call this earlier, which is why we did not see shit lol.
            }
        }
    }

    public void CreateItemsList()
    {
        foreach (Transform child in contentParent) //each time it destroys the existing gameobject in the scene first, NO DUPLICATES
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (InventorySlot inventorySlot in playerInventory.InventorySlots)
        {
            InventoryUIPrefab inventoryuiPrefab = Instantiate(inventoryUIPrefab, contentParent); //creates the inventory slot

            inventoryuiPrefab.SetItem(inventorySlot); //sets the item data
        }
    }
}
