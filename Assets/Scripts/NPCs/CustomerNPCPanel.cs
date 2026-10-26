using UnityEngine;
using UnityEngine.UI;

public class CustomerNPCPanel : MonoBehaviour
{
    public GameObject customerPanel;

    [SerializeField]
    private Text orderText;


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

    public void SetOrderText(string text)
    {
        orderText.text = text;
    }

}
