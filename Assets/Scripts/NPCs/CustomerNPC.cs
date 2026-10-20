using System;
using UnityEngine;

public class CustomerNPC : MonoBehaviour
{
    public Transform standTarget;

    [SerializeField]
    private float moveSpeed = 2f;

    [SerializeField]
    private float stoppingDistance = 5;

    [SerializeField]
    private Vector3 flyDistance;

    [SerializeField]
    private bool startedTalking = false;

    public Transform playerTarget;

    [SerializeField]
    private CustomerNPCPanel customerPanel;

    [SerializeField]
    private string orderText = "I'd like 2 lemonades, please!";

    [SerializeField]
    private int orderQuantity = 2;

    public string OrderText => orderText;
    public int OrderQuantity => orderQuantity;

    private CustomerState currentState = CustomerState.Waiting;

    public event Action<CustomerNPC> FinishedLeaving;

    public void SetState(CustomerState newState)
    {
        currentState = newState;

        if(newState == CustomerState.Leaving)
        {
            flyDistance = transform.position + Vector3.up * 20f;
            Debug.Log("Customer is leaving.");
        }
    }

    public void Initialize(
        Transform stand,
        Transform player,
        CustomerNPCPanel panel)
    {
        standTarget = stand;
        playerTarget = player;
        customerPanel = panel;
    }

    public void Update()
    {
        switch (currentState)
        {
            case CustomerState.Waiting:
                ///it waits till i approach duh
                break;

            case CustomerState.Approaching:
                NPCMove();
                break;

            case CustomerState.Ordering:
                // Wait for the order to finish.
                break;

            case CustomerState.Leaving:
                FlyAway();
                break;
        }
    }

    public void NPCMove()
    {

        Vector3 npcPosition = gameObject.transform.position;

        float totalDistance = Vector3.Distance(npcPosition, standTarget.transform.position);
        if (totalDistance > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, standTarget.transform.position, moveSpeed * Time.deltaTime);
            transform.LookAt(standTarget);
            //Debug.Log("Moving");
        }
        else
        {
            Vector3 playerPosition = playerTarget.transform.position;
            transform.LookAt(playerPosition);

            currentState = CustomerState.Ordering;
            if (!startedTalking)
            {
                customerPanel.TurnOnDialouge();
                startedTalking = true;
                Debug.Log(currentState);
            }
            else
            {
                return;
            }
        }
    }

    public void ShowDialogue()
    {
        if (currentState == CustomerState.Ordering)
        {
            customerPanel.TurnOnDialouge();
            startedTalking = true;
        }
    }

    public void ResetTalking()
    {
        customerPanel.TurnOffDialouge();
        startedTalking = false;
    }

    public void FlyAway()
    {
        transform.position = Vector3.MoveTowards(transform.position, flyDistance, moveSpeed * Time.deltaTime);

        float distance = Vector3.Distance(transform.position, flyDistance);

        if (distance < 0.1)
        {
            FinishedLeaving?.Invoke(this);
        }
    }
}
