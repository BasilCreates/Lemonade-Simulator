using System;
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
        if (customerQueue.Count < 10)
        {
            SpawnCustomer();
        }
    }

    public void SpawnCustomer()
    {
        CustomerNPC customer = customerPool.GetCustomer(); //storing our customer in a variable, its easier to work with it this way.
        if (customer != null)
        {
            int queueIndex = customerQueue.Count;
            Vector3 target = CustomerSpotInLine(queueIndex);
            customer.SetSpotInLine(target);

            customer.transform.position = CustomerSpotInLine(queueIndex + 1);
            //spawnPoint.position - spawnPoint.forward * customerSpace * nextCustomerIndex;

            //nextCustomerIndex++; 
            customer.transform.rotation = spawnPoint.rotation;
            customerQueue.Enqueue(customer);

            customer.Initialize(standTarget, playerTarget, customerPanel);
            Debug.Log("Spawned a customer.");
            customer.name = $"Customer_{nextCustomerIndex}";
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
        Debug.Log("Getting first customer in queue.");
        return customerQueue.Peek(); //gets who the first customer in the queue is, but does not remove them from the queue

    }

    public CustomerNPC DequeueCustomer()
    {
        if (customerQueue.Count == 0)
        {
            return null;
        }

        CustomerNPC customer = customerQueue.Dequeue();
        //Debug.Log($"Dequeued Customer: {customer.GetEntityId()}");

        nextCustomerIndex--;

        Debug.LogWarning("Despawning Customer.");
        customerPool.ReturnCustomer(customer);
        UpdateSpotInLine();
        Debug.Log("calling for next customer!");
        return customer;
    }

    private Vector3 CustomerSpotInLine(int queueIndex)
    {

        return spawnPoint.position - spawnPoint.forward * customerSpace * queueIndex;

    }

    public void UpdateSpotInLine()
    {
        Debug.Log("Updating customer spots in line.");
        CustomerNPC[] customers = customerQueue.ToArray();

        for (int i = 0; i < customers.Length; i++)
        {
            Vector3 target = CustomerSpotInLine(i);
            customers[i].SetSpotInLine(target);
            Debug.Log($"{customers[i].name} | Index: {i} | Target: {target}");
        }


    }
}
