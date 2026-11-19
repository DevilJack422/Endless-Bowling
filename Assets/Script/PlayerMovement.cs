using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 10f;
    public float sideSpeed = 5f;
    public float jumpForce = 5f;
    bool isGround = true;
    private Rigidbody rb;
    [Header("Lane Boundaries")]
    public float maxBoundary = 2.75f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Freeze rotation to prevent the player from tipping over
        rb.freezeRotation = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        isGround = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGround = false;
        }
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal") * sideSpeed;

        Vector3 move = transform.forward * forwardSpeed
                        + transform.right * moveX;

        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);

        Vector3 clampPosition = transform.position;
        clampPosition.x = Mathf.Clamp(clampPosition.x, -maxBoundary, maxBoundary);
        transform.position = clampPosition;
    }
}
