
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [SerializeField]
    private PlayerInventory playerInventory;

    [SerializeField]
    private PlayerMoney playerMoney;

    [SerializeField]
    private CustomerNPC activeCustomer;

    [SerializeField]
    private int pricePerServing = 2;

    private Lemonade lemonade;

    private void Awake()
    {
        lemonade = new Lemonade();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartOrder();
        }
    }

    public void SetActiveCustomer(CustomerNPC customer)
    {
        activeCustomer = customer;
    }

    public void StartOrder()
    {
        if (activeCustomer == null)
        {
            Debug.Log("There is no active customer.");
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
            int requiredAmount =
                requirement.AmountPerServing * servings;

            if (!playerInventory.HasEnoughItems(
                    requirement.ItemName, requiredAmount))
            {
                Debug.Log(
                    "Not enough " + requirement.ItemName +
                    " to complete the order."
                );
                return;
            }
        }

        // Step 2: All ingredients are available. Consume them.
        foreach (IngredientRequirement requirement in lemonade.Requirements)
        {
            int requiredAmount =
                requirement.AmountPerServing * servings;

            bool removed = playerInventory.RemoveItems(
                requirement.ItemName, requiredAmount);

            if (!removed)
            {
                Debug.LogError(
                    "Unexpected inventory failure for " +
                    requirement.ItemName
                );
                return;
            }
        }

        // Step 3: Calculate and receive payment.
        int payment = pricePerServing * servings;
        playerMoney.ReceivePayment(payment);

        Debug.Log(
            "Order completed: " + servings +
            " servings sold for $" + payment
        );

        // TODO: Complete the customer interaction and spawn the next customer.
    }
}
