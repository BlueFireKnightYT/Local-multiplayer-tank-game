using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject player;
    Shoot shootScript;

    [SerializeField] GameObject bulletAudioPlayer;

    Rigidbody rb;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float destroyTimer = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        shootScript = player.GetComponent<Shoot>();
        Destroy(this.gameObject, destroyTimer);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = transform.forward * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        Instantiate(bulletAudioPlayer, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
