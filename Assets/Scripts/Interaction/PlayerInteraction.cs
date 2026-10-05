using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private float interactionRange;

    [SerializeField]
    private LayerMask interactionLayer;

    private IInteractable interactable;



    public void Update()
    {
        Interact();
    }



    public void Interact()
    {

        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;
        RaycastHit hitInfo;

        if (!Physics.Raycast(origin, direction, out hitInfo, interactionRange, interactionLayer))
        {
            return;
        }
            interactable = hitInfo.collider.GetComponent<IInteractable>();
        if (interactable == null)
        {
            return;
        }
            Vector3 hitPoint = hitInfo.point;
            float hitDistance = hitInfo.distance; 
            Debug.Log("We found an interactable Object!");
            Debug.DrawLine(origin, hitPoint, Color.red, 5f);

            if (Input.GetKeyDown(KeyCode.E))
            {
                StartInteraction();
            }
        
    }

    public void StartInteraction()
    {
        interactable.StartInteraction();
    }
}
