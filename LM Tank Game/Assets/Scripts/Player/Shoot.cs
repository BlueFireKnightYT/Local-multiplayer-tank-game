using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float shootCooldown = 0.5f;

    float timeRemaining;
    bool canShoot = true;

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            canShoot = true;
        }
    }
    private void ShootGun()
    {
        if (canShoot)
        { 
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            BulletScript bulletScript = bullet.GetComponent<BulletScript>();

            bulletScript.player = this.gameObject;

            canShoot = false;
            timeRemaining = shootCooldown;
        }
    }

    public void ShootInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ShootGun();
        }
    }
}
