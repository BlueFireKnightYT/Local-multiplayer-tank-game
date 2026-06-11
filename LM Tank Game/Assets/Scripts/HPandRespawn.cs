using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HPandRespawn : MonoBehaviour
{
    public int maxHP = 5;
    int currentHP;

    public Transform respawnPoint;
    [SerializeField] Slider hpBar;

    public GameObject respawnTimerTxt;

    bool didCoroutineStart = false;
    private void Start()
    {
        currentHP = maxHP;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            currentHP--;
            if (currentHP <= 0 && !didCoroutineStart)
            {
                didCoroutineStart = true;
                StartCoroutine(Respawn());
            }
            updateHpBar();
            Debug.Log(currentHP);
        }
    }

    private void updateHpBar()
    {
        hpBar.value = currentHP;
    }

    private IEnumerator Respawn()
    {
        currentHP = maxHP;
        Instantiate(respawnTimerTxt, transform.position, Quaternion.identity);
        transform.position = new Vector3(-1000, transform.position.y, -1000);
        yield return new WaitForSeconds(5);
        transform.position = respawnPoint.position;
        didCoroutineStart = false;
    }
}
