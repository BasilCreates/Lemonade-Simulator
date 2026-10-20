
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private PlayerInventory playerInventory;

    [SerializeField]
    private PlayerMoney playerMoney;

    [SerializeField]
    private CustomerNPC activeCustomer;

    [Header("Pricing")]
    [SerializeField, Min(1)] //Min in serialize field allows us to only allow a MINIMUM of a certain number of this THING we are serializing. basically 1 serving is the least you can put, not 0
    private int pricePerServing = 2;

    private Lemonade lemonade;

    private void Awake()
    {
        lemonade = new Lemonade();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) //E controls the transatction logic, it unlocks it.
        {
            StartOrder();
        }
    }

    //this takes the customer who is currently at the stand and marks them as active. duh.
    public void SetActiveCustomer(CustomerNPC customer)
    {
        activeCustomer = customer;
    }

    public void StartOrder()
    {
        if (activeCustomer == null)  //checks if the customer is active in the scene
        {
            Debug.Log("There is no active customer.");
            return;
        }

        if (playerInventory == null || playerMoney == null) //Checks if the player Inventory is null
        {
            Debug.LogError(
                "OrderManager is missing an inventory or money reference."
            );
            return;
        }

        int servings = activeCustomer.OrderQuantity;

        if (servings <= 0 || pricePerServing <= 0)
        {
            Debug.LogWarning("Invalid order quantity or price.");
            return;
        }

        // Step 1: Check every ingredient before removing anything.
        foreach (IngredientRequirement requirement in lemonade.Requirements)
        {
            int requiredAmount = requirement.AmountPerServing * servings;

            if (!playerInventory.HasEnoughItems(
                    requirement.ItemName, requiredAmount))
            {
                Debug.Log(
                    "Order failed: not enough " +
                    requirement.ItemName + "."
                );
                return;
            }
        }

        // Step 2: Remove the ingredients needed for the order.
        foreach (IngredientRequirement requirement in lemonade.Requirements)
        {
            int requiredAmount = requirement.AmountPerServing * servings;

            bool removed = playerInventory.RemoveItems(
                requirement.ItemName, requiredAmount);

            if (!removed)
            {
                Debug.LogError(
                    "Could not remove " + requirement.ItemName +
                    ". Check inventory dude."
                );
                return;
            }
        }

        // Step 3: Calculate payment and update the player's money.
        int payment = pricePerServing * servings;
        playerMoney.ReceivePayment(payment);

        Debug.Log(
            "Order completed: " + servings +
            " servings sold for $" + payment + "."
        );

        // Step 4: logic AFTER order is complete, to do soon lol
        //Debug.Log("Order completed. Customer leaves.");
        activeCustomer.SetState(CustomerState.Leaving);
    }
}
