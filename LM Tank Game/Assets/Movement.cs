using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Vector2 moveInput;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //rb.AddForce(moveInput.x * moveSpeed, 0, moveInput.y * moveSpeed, ForceMode.Acceleration);

        //rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, moveSpeed);

        rb.linearVelocity = new Vector3(moveInput.x * moveSpeed, 0f, moveInput.y * moveSpeed);
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log(moveInput);
    }
}
