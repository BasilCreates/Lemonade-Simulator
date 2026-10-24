using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
public class CustomerPool: MonoBehaviour
{
    [SerializeField]
    private GameObject customerPrefab; 

    private Stack<CustomerNPC> availableNPCPool = new Stack<CustomerNPC>(); //stack is a data structure that allows us to store and retrieve objects in a last-in-first-out (LIFO) manner. In this case, we are using it to manage the pool of active customer NPCs. (shoutout claude)

    [SerializeField, Min(1)]
    private int maxCustomers = 10;


    private void Start()
    {

        Debug.Log("Generating objects in Customer Pool...");
        for (int i = 0; i < maxCustomers; i++)
        {
           CustomerNPC customer =  Instantiate(customerPrefab, transform).GetComponent<CustomerNPC>();

            customer.gameObject.SetActive(false);
                availableNPCPool.Push(customer);
        }
        Debug.Log($"Customer Pool populated with {availableNPCPool.Count} customers.");
    }

    public CustomerNPC GetCustomer()
    {
        if (availableNPCPool.Count > 0) //if there is a customer available in the pool, it will pop one out and return it to the hashset to be set active.
        {
           CustomerNPC customer = availableNPCPool.Pop();
            customer.gameObject.SetActive(true);
            Debug.Log("Customer activated from pool");

            return customer;
        }

        return null;
    }

    public void ReturnCustomer(CustomerNPC customer)
    {
        if (customer == null) //if there is no customer
        {
            return;
        }
        Debug.Log("Returning customer to pool");
        customer.ResetTalking(); //reset the talking state of the customer
        customer.gameObject.SetActive(false); //turns it off
        availableNPCPool.Push(customer); //puts it back into the stack pool for later
        customer.SetState(CustomerState.Waiting); //set the state back to waiting

    }

}
