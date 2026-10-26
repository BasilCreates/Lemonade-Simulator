using UnityEngine;
using UnityEngine.UI;
public class SellerOpen : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject sellerDialougeText;

    [SerializeField]
    private GameObject storeOptionsPanel;

    public GameObject itemOptions;

    public GameObject menuPanel; //use a master menu, shows different info, but the same overall shell

    public GameObject walkToShopPanel;


    private bool sellerTalk = false;


    private void Awake()
    {

        SellerCloses();
    }

    public void Update()
    {
        Closetabs();
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
            walkToShopPanel.SetActive(true);
        }
    }

    public void SellerOpens()
    {
        sellerDialougeText.SetActive(true);
        storeOptionsPanel.SetActive(true);
        Debug.Log("Turning on panels");
        walkToShopPanel.SetActive(false);
        sellerTalk = true;
    }

    public void SellerCloses()
    {
        itemOptions.SetActive(false);
        menuPanel.SetActive(false);
        sellerDialougeText.SetActive(false);
        storeOptionsPanel.SetActive(false);
        sellerTalk=false;
    }

    public void Closetabs()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //an escape chain to get out of the menu. nice and easy.
        {
            SellerCloses();
        }
    }
}
