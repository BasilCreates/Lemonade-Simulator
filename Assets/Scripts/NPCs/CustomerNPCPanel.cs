using UnityEngine;

public class CustomerNPCPanel : MonoBehaviour
{
    public GameObject customerPanel;


    private void Awake()
    {
        customerPanel.SetActive(false);
    }
    public void TurnOnDialouge()
    {
        customerPanel.SetActive(true);
    }

    public void TurnOffDialouge()
    {
        customerPanel.SetActive(false);
    }

}
