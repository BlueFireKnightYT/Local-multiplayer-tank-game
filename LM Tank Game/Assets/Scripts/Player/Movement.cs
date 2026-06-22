using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private GameObject Cannon;

    public float sensitivity;

    private Vector2 moveInput;
    private Vector2 lookInput;
    private Rigidbody rb;

    private bool moving;

    public AudioSource audioSource;
    public AudioClip drivingSound;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        rb = GetComponent<Rigidbody>();
        audioSource.clip = drivingSound;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = transform.forward * moveInput.y * moveSpeed;
        transform.eulerAngles += new Vector3(0, moveInput.x * turnSpeed, 0);

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
            audioSource.loop = true;
            audioSource.Play();

            
        }
        if (context.canceled)
        {
            moving = false;
            audioSource.Stop();
        }
    }

    public void Look(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
}
