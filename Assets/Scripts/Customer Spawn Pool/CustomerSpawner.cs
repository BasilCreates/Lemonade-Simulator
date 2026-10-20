using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] 
    private CustomerPool customerPool;

    [SerializeField] 
    private Transform spawnPoint;

    [SerializeField]
    private float customerSpace = 2f;

    [SerializeField]
    private int nextCustomerIndex = 0;

    [SerializeField] 
    private Transform standTarget;

    [SerializeField] 
    private Transform playerTarget;

    [SerializeField] 
    private CustomerNPCPanel customerPanel;



    private Queue<CustomerNPC> customerQueue = new Queue<CustomerNPC>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            SpawnCustomer();
        }
    }

    public void SpawnCustomer()
    {
        CustomerNPC customer = customerPool.GetCustomer(); //storing our customer in a variable, its easier to work with it this way.
        if (customer != null)
        {
            customer.transform.position =
                spawnPoint.position - spawnPoint.forward * customerSpace * nextCustomerIndex;

            nextCustomerIndex++;
            customer.transform.rotation = spawnPoint.rotation;
            customerQueue.Enqueue(customer);
            customer.Initialize(standTarget, playerTarget, customerPanel);
            Debug.Log("Spawned a customer.");
        }
        else
        {
            Debug.LogWarning("No available customers in the pool to spawn.");
        }
    }

    public CustomerNPC GetFirstCustomer()
    {
        if( customerQueue.Count == 0)
        {
            return null;
        }
        return customerQueue.Peek(); //gets who the first customer in the queue is, but does not remove them from the queue.

    }

    public CustomerNPC DequeueCustomer()
    {
        if (customerQueue.Count == 0)
        {
            return null;
        }

        CustomerNPC customer = customerQueue.Dequeue();

        nextCustomerIndex--;

        Debug.LogWarning("Despawning Customer.");
        customerPool.ReturnCustomer(customer);

        return customer;
    }
}
