using UnityEngine;
using UnityEngine.UI;

public class SellerOpen : MonoBehaviour, IInteractable
{
    public GameObject sellerPanel;
    public GameObject storeOptionsPanel;

    private bool sellerTalk = false;


    private void Awake()
    {
        SellerCloses();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartInteraction();

        }
        else
        {
            SellerCloses();
        }
    }

    public void StartInteraction()
    {
        Debug.Log("Hit!");
        SellerOpens();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SellerCloses();
        }
    }

    public void SellerOpens()
    {
        sellerPanel.SetActive(true);
        storeOptionsPanel.SetActive(true);
        Debug.Log("Turning on panels");
        sellerTalk = true;
    }

    public void SellerCloses()
    {
        sellerPanel.SetActive(false);
        storeOptionsPanel.SetActive(false);
        sellerTalk=false;
    }

}
