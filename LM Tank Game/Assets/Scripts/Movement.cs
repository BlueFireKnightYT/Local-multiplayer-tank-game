using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject Cannon;

    public float sensitivity;

    private Vector2 moveInput;
    private Vector2 lookInput;
    private Rigidbody rb;

    private bool moving;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(moveInput.x * moveSpeed, 0f, moveInput.y * moveSpeed);

        if (!moving)
        {
            Cannon.transform.Rotate(new Vector3(0, lookInput.x, 0));
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if (context.started)
        {
            moving = true;
        }
        if (context.canceled)
        {
            moving = false;
        }
    }

    public void Look(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
}
