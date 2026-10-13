using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 10f;

    [SerializeField]
    private float runSpeed = 20f;

    [SerializeField]
    private float gravityMultiplier = -5f;

    [SerializeField]
    private float jumpHeight = 5f;

    private float verticalVelocity;

    private CharacterController characterCon;



    //Grabs our CharacterCon, awake is faster than start
    private void Awake()
    {
        characterCon = GetComponent<CharacterController>();
    }


    //updates movement
    private void Update()
    {
        Movement();
        Jump();
    }

    //Directional Checks, generates movement, smooths the momvement so it aint jank. Gravitational check
    public void Movement()
    {
        float currentSpeed = walkSpeed; //flexible to easily switch between walk and runSpeed.
        if (characterCon.isGrounded && Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed; 
        }

        if (characterCon.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }
        verticalVelocity += gravityMultiplier * Time.deltaTime;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3 (-horizontal, 0, -vertical) * currentSpeed; //changed it to be more basic for the prototype

        characterCon.Move(movement * Time.deltaTime);
    }


    //Separated our jump and movement just to make it cleaner. Run 3 checks before jump is enabled. character controller has built in isGrounded bool
    public void Jump()
    {
        if (characterCon.isGrounded && jumpHeight > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = Mathf.Sqrt(2f * -gravityMultiplier * jumpHeight);

            
        }
    }


}
