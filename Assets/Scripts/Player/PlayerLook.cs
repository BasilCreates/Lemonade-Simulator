using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]
    private float mouseSensitivity = 100f;

    private float mouseX;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined; //keeps the bounds of the mouse to the screen area, easy to test
        //Cursor.visible = false;
    }

    public void Update()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        
        float rotation = mouseX * mouseSensitivity * Time.deltaTime;

        transform.Rotate(0, rotation, 0);
    }

}
