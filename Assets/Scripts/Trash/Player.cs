using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    public PlayerInput playerInput;
    private InputAction spaceAction;
    private InputAction horizontalAction;
    private Rigidbody rb;
    private bool inputJump;

    public bool isGrounded;

    private void Start()
    {
        spaceAction = playerInput.actions["Space"];
        horizontalAction = playerInput.actions["Horizontal"];
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!inputJump)
        {
            inputJump = spaceAction.WasPerformedThisFrame();
        }

        float horizontal = horizontalAction.ReadValue<float>();

        if (horizontal != 0)
        {
            transform.Translate(Vector3.right * horizontal * 4 * Time.deltaTime);
        }
    }
    
    private void FixedUpdate()
    {
        if (inputJump && isGrounded)
        {
            rb.AddForce(Vector3.up * 3, ForceMode.VelocityChange);
            inputJump = false;
            isGrounded = false;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }
    private void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Resurrection floor")
        {
            transform.position = new Vector3 (0.13f, 3.68f,-1.55f);
        }
        else
        {
            Destroy(other.gameObject);
        }

    }
}
