using UnityEngine;

public class CustomerNPC : MonoBehaviour
{
    public Transform standTarget;

    [SerializeField]
    private float moveSpeed = 2f;

    [SerializeField]
    private float stoppingDistance = 5;

    [SerializeField]
    private bool startedTalking = false;

    public Transform playerTarget;

    [SerializeField]
    private CustomerNPCPanel customerPanel;


    public void Update()
    {

    }

    public void NPCMove()
    {
        Vector3 npcPosition = gameObject.transform.position;

        float totalDistance = Vector3.Distance(npcPosition, standTarget.transform.position);
        if (totalDistance > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, standTarget.transform.position, moveSpeed * Time.deltaTime);
            transform.LookAt(standTarget);
            Debug.Log("Moving");
        }
        else
        {
            Vector3 playerPosition = playerTarget.transform.position;
            transform.LookAt(playerPosition);
            if (!startedTalking)
            {
                customerPanel.TurnOnDialouge();
                startedTalking = true;
            }
            else
            {
                return;
            }
        }
    }

    public void ResetTalking()
    {
        startedTalking = false;
    }
}
