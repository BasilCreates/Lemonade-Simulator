using UnityEngine;
using System.Collections.Generic;
public class CustomerPool: MonoBehaviour
{
    [SerializeField]
    private GameObject customerPrefab; 

    private Stack<CustomerNPC> availableNPCPool = new Stack<CustomerNPC>(); //stack is a data structure that allows us to store and retrieve objects in a last-in-first-out (LIFO) manner. In this case, we are using it to manage the pool of active customer NPCs. (shoutout claude)

    private HashSet<CustomerNPC> activeNPCs = new HashSet<CustomerNPC>(); //HashSet is a data structure that allows us to store and retrieve objects in a way that ensures uniqueness. In this case, we are using it to keep track of the currently active customer NPCs.
    [SerializeField, Min(1)]
    private int maxCustomers = 10;


    private void Start()
    {

        Debug.Log("Initializing Customer Pool...");
        for (int i = 0; i < maxCustomers; i++)
        {
           CustomerNPC customer =  Instantiate(customerPrefab, transform).GetComponent<CustomerNPC>();

            customer.gameObject.SetActive(false);
                availableNPCPool.Push(customer);
        }
        Debug.Log($"Customer Pool initialized with {availableNPCPool.Count} customers.");
    }

    public CustomerNPC GetCustomer()
    {
        if (availableNPCPool.Count > 0) //if there is a customer available in the pool, it will pop one out and return it to the hashset to be set active.
        {
           CustomerNPC customer = availableNPCPool.Pop();

            activeNPCs.Add(customer); 
            customer.gameObject.SetActive(true);

            return customer;
        }

        return null;
    }

    public void ReturnCustomer(CustomerNPC customer)
    {
        if (activeNPCs.Contains(customer)) //if there is a customer
        {
            activeNPCs.Remove(customer); //it removes said customer from the activeNPCs hashset
            customer.gameObject.SetActive(false); //turns it off
            availableNPCPool.Push(customer); //puts it back into the stack pool for later
        }
        else
        {
            Debug.LogWarning("Attempted to return a customer that is not active.");
        }
    }
}
