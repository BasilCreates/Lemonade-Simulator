using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour //Where we DISPLAY the specific item itself, with it's correct credientials.
{
    public Text itemName;
    public Image itemImage;
    public Text itemPrice;
    public Text itemQuantity;

    private Item item;

    private PlayerMoney playerMoney;


    public void SetPlayerMoney(PlayerMoney setPlayerMoney) //set up method to CARRY the reference to the ITEM prefabs so they dont need to look for it.
    {
        playerMoney = setPlayerMoney;
    }

    public void SetItem(Item newItem)
    {
        item = newItem;
        itemName.text = item.Name; //when placing items, make sure to refer to what their type is. if its text, add .text, if its an image, say Image or sprite. think of it like making an incredibly throrough breakdown.
        itemImage.sprite = item.ItemImage;
        itemPrice.text = item.PriceTag.ToString(); //since the PriceTag and ItemQuantity are not strings natively, they must be converted to show them
        itemQuantity.text = item.ItemQuantity.ToString();
    }

    public void onBuyClicked()
    {
        playerMoney.BuyItem(item); //we call our playermoney method to complete the purchase, the math is there.
    }
}
