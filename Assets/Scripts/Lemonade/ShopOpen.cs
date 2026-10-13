using UnityEngine;

public class ShopOpen : MonoBehaviour
{
    public CustomerNPC npc;
    [SerializeField]
    private CustomerNPCPanel customerPanel;

    private void OnTriggerStay(Collider other) //ontrigger stay means as long as I am on the trigger do this
    {
        if (other.CompareTag("Player")) //checks the gameplayer's tag
        {
            Debug.Log("Shop is open!");
            OpenShop(); //runs openshop
        }
        
    }

    public void OpenShop()
    {
        npc.NPCMove();
    }

    private void OnTriggerExit(Collider other)
    {
        {
            if (other.CompareTag("Player")) //checks the gameplayer's tag
            {
                Debug.Log("Shop is closed!");
                customerPanel.TurnOffDialouge();
                npc.ResetTalking(); //set the bool to false so that when ran into again, it triggers the text to come up again
            }
        }

    }
}
