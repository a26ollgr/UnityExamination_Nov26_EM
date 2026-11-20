using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundDistance;
    
    private Animator animator;

    public bool movementActive = true;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool onGround = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator =  GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundChecker();

        if(movementActive)
            rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);

        if (rb.linearVelocity.x != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && onGround && movementActive)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void GroundChecker()
    {
        if(Physics2D.OverlapArea(transform.position - new Vector3(0.5f, 0.4f,0), transform.position + new Vector3(0.5f, (-0.4f - groundDistance), 0), groundLayer))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }

    private void OnDrawGizmos()
    {
        Vector2 pointA = transform.position - new Vector3(0.5f, 0.4f, 0f);
        Vector2 pointB = transform.position + new Vector3(0.5f, -0.4f - groundDistance, 0f);

        Vector3 center = new Vector3((pointA.x + pointB.x) * 0.5f, (pointA.y + pointB.y) * 0.5f, transform.position.z);
        Vector3 size = new Vector3(Mathf.Abs(pointB.x - pointA.x), Mathf.Abs(pointB.y - pointA.y), 0.01f);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(center, size);
    }

}
