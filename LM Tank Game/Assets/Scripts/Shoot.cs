using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

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
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
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
