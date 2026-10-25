using UnityEngine;

public class LemonadeShopManager : MonoBehaviour
{
    [SerializeField]
    private CustomerSpawner customerSpawner;

    [SerializeField]
    private ShopOpen shopOpen;

    private CustomerNPC activeCustomer;

    [SerializeField]
    private OrderManager orderManager;

    private void OnEnable()
    {
        // Listen for the player entering or leaving the shop.
        // Assumes shopOpen is assigned in the Inspector.
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
        Debug.Log("Player entered the shop.");

        StartServingNextCustomer();

        if (orderManager != null)
        {
            orderManager.SetActiveCustomer(activeCustomer);

        }

        activeCustomer.ShowDialogue();
    }

    private void HandlePlayerExitedShop()
    {
        Debug.Log("Player exited the shop.");
        PlayerExitsShop();
    }




    public void StartServingNextCustomer()
    {
        // Don't assign another customer while one is being served.
        if (activeCustomer != null)
        {
            return;
        }

        // Ask the spawner who is first in line.
        CustomerNPC nextCustomer = customerSpawner.GetFirstCustomer();

        if (nextCustomer == null)
        {
            Debug.Log("No customers in line.");
            return;
        }
        orderManager.SetActiveCustomer(nextCustomer);
        activeCustomer = nextCustomer;

        // We'll tell this customer to approach the stand here.
        activeCustomer.SetState(CustomerState.Approaching);
        customerSpawner.UpdateSpotInLine();
        activeCustomer.FinishedLeaving += HandlePlayerLeaving;

    }


    public void PlayerExitsShop()
    {
        if (activeCustomer == null)
        {
            return;
        }

        activeCustomer.ResetTalking(); 
    }

    private void HandlePlayerLeaving(CustomerNPC customer)
    {
        customer.FinishedLeaving -= HandlePlayerLeaving;
        activeCustomer = null;
        Debug.Log($"Leaving event: {customer.GetEntityId()}");
        customerSpawner.DequeueCustomer();
        StartServingNextCustomer();
        Debug.Log("Customer has left the shop.");
    }
}