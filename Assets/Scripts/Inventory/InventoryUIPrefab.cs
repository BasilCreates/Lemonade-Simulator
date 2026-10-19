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

    public void SetItem(InventorySlot slot)
    {
        itemName.text = slot.ItemName;
        itemQuantity.text = slot.ItemQuantity.ToString();
    }
}