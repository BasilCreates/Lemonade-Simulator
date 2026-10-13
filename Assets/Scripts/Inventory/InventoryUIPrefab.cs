using UnityEngine;
using UnityEngine.UI;

public class InventoryUIPrefab : MonoBehaviour
{
    [SerializeField]  //parameters for item slot
    private Text itemName;

    [SerializeField]
    private Text itemQuantity;

    [SerializeField]
    private Image itemImage;

    public void SetItem(Item item) //matching our data to the right slots
    {
        itemName.text = item.Name; 
        itemQuantity.text = item.ItemQuantity.ToString();
        itemImage.sprite = item.ItemImage;
    }
}