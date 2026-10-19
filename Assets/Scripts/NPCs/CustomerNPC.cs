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

    [SerializeField]
    private string orderText = "I'd like 2 lemonades, please!";

    [SerializeField]
    private int orderQuantity = 2;

    public string OrderText => orderText;
    public int OrderQuantity => orderQuantity;

    private bool isFlyingAway = false;


    private void Start()
    {

    }

    public void Update()
    {
        if(isFlyingAway == true)
        {
            FlyAway();
        }
    }

    public void NPCMove()
    {
        if(isFlyingAway)
        {
            return;
        }
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

    public void FlyAway()
    {
        isFlyingAway = true;
        Vector3 targetArea = transform.position + Vector3.up * 100f;

        transform.position = Vector3.MoveTowards(transform.position, targetArea, moveSpeed * Time.deltaTime);
    }
}
