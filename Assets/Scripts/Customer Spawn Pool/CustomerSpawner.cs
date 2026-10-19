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
            Debug.Log("Spawned a customer.");
        }
        else
        {
            Debug.LogWarning("No available customers in the pool to spawn.");
        }
    }
}
