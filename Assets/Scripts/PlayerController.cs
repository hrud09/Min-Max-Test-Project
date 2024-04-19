using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float acceleration = 10f;
    public float deceleration = 5f;
    public float maxSpeed = 10f;
    public float minSpeed = 2f;
    public float rotationSpeed = 10f;

    private Rigidbody rb;
    private Animator animator;
    public float currentSpeed = 0f;
    public float speed_m = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0f;
        movement.Normalize();
        print(movement.magnitude);
        if (movement.magnitude > 0.3f)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.deltaTime);
            rb.velocity = movement * currentSpeed;
        }
        else
        {
            currentSpeed = 0;
            rb.velocity = Vector3.zero;
        }

      

        speed_m = rb.velocity.magnitude / maxSpeed;

        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        animator.SetFloat("Speed", speed_m);
    }
}
