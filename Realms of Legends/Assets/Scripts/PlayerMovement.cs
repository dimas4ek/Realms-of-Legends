using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Animator animator;
    private bool isMoving = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        //
        //Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.fixedDeltaTime;
        //
        //rb.MovePosition(rb.position + transform.TransformDirection(movement));
        //
        //animator.SetBool("isWalk", movement.magnitude > 0.1f);

        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        animator.SetBool("isWalk", false);

        if (Input.GetKey(KeyCode.S))  
        {
            animator.SetBool("isWalk", moveInput.magnitude > 0.1f);
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.W)) 
        {
            animator.SetBool("isWalk", moveInput.magnitude > 0.1f);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D))  
        {
            animator.SetBool("isWalk", moveInput.magnitude > 0.1f);
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.A))  
        {
            animator.SetBool("isWalk", moveInput.magnitude > 0.1f);
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        }

        if(Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetTrigger("Attack");
        }

    }
}