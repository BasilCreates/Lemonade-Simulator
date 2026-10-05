using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    [SerializeField]
    private float grabRange = 10f;

    private GameObject heldObject;

    [SerializeField]
    private LayerMask GrabbableLayer;

    public Transform grabArea;






    public void Update()
    {
        Grab();
    }

    public void Grab()
    {

        if (!Input.GetKeyDown(KeyCode.R))
        {
            return;
        }

            //if its holding sum, drop it
            if(heldObject != null)
                {
                    heldObject.transform.SetParent(null);
                    heldObject = null;
                    return;
                }


            //defining where the raycast is coming from
            Vector3 origin = transform.position;
            Vector3 direction = transform.forward;

            //creating a raycast variable
            RaycastHit hitInfo;

            if (Physics.SphereCast(origin, 0.5f, direction, out hitInfo, grabRange, GrabbableLayer))
            {
                Vector3 hitPoint = hitInfo.point;
                float distance = hitInfo.distance;
                Debug.Log("hit a grabbable object!");
                Debug.DrawLine(origin, hitPoint, Color.red, 5f);

                heldObject = hitInfo.collider.gameObject;
                heldObject.transform.SetParent(grabArea);
                heldObject.transform.localPosition = Vector3.zero;
                heldObject.transform.localRotation = Quaternion.identity;
            }
    }
}
