using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float destroyTimer = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(this.gameObject, destroyTimer);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = transform.forward * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        Destroy(this.gameObject);
    }
}
