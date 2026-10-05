using UnityEngine;

public class Seller : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject textPanel;

    [SerializeField]
    private ShopMenuUI shopMenu;



    private void Awake()
    {
        textPanel.SetActive(false);

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(textPanel.activeSelf)
            {
                textPanel.SetActive (false);
            }
        }
    }
    public void StartInteraction()
    {
        textPanel.SetActive(true);
        shopMenu.OpenShopMenu();
    }
}
