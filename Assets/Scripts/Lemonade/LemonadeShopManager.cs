using UnityEngine;

public class LemonadeShopManager : MonoBehaviour
{
    [SerializeField]
    private CustomerNPC customerNPC;

    [SerializeField]
    private GameObject customerPanel;

    [SerializeField]
    private ShopOpen shopOpen;

    private void OnEnable()
    {
        shopOpen.PlayerEnteredShop += HandlePlayerEnteredShop;
        shopOpen.PlayerExitedShop += HandlePlayerExitedShop;
    }

    private void OnDisable()
    {
        shopOpen.PlayerEnteredShop -= HandlePlayerEnteredShop;
        shopOpen.PlayerExitedShop -= HandlePlayerExitedShop;
    }

    private void HandlePlayerEnteredShop()
    {
        // Handle customer interaction here.
    }

    private void HandlePlayerExitedShop()
    {
        // End customer interaction here.
    }
}
