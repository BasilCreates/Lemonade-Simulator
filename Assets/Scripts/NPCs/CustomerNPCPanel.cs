using UnityEngine;
using UnityEngine.UI;

public class CustomerNPCPanel : MonoBehaviour
{
    public GameObject customerPanel;

    [SerializeField]
    private Text orderText;

    [SerializeField]
    private GameObject playerisOutOfFrame;

    [SerializeField]
    private Text playerIsOutOfText;


    private void Awake()
    {
        customerPanel.SetActive(false);
        playerisOutOfFrame.SetActive(false);
    }
    public void TurnOnDialouge()
    {
        customerPanel.SetActive(true);
    }

    public void TurnOffDialouge()
    {
        customerPanel.SetActive(false);
        playerisOutOfFrame.SetActive(false);
    }

    public void SetOrderText(string text)
    {
        orderText.text = text;
    }

    public void PlayerIsOutOf(string itemName)
    {
        playerisOutOfFrame.SetActive(true);

        playerIsOutOfText.text = "Player is out of " + itemName + ". Go back to the store";

    }
}
