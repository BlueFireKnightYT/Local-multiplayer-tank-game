using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HPandRespawn : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip playerDeathSound;

    public int maxHP = 5;
    int currentHP;

    public Transform respawnPoint;
    public int playerNum;
    [SerializeField] Slider hpBar;

    public GameObject respawnTimerTxt;

    bool didCoroutineStart = false;
    private void Start()
    {
        currentHP = maxHP;
        audioSource = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {

            currentHP--;
            if (currentHP <= 0 && !didCoroutineStart)
            {
                currentHP = maxHP;
                transform.position = respawnPoint.position;

                //Get the HP script from the other player
                BulletScript bulletScript = other.GetComponent<BulletScript>();
                GameObject otherPlayer = bulletScript.player;
                HPandRespawn otherHpScript = otherPlayer.GetComponent<HPandRespawn>();

                PointCounter.Instance.AddPoint(otherHpScript.playerNum);

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
        audioSource.PlayOneShot(playerDeathSound);
        currentHP = maxHP;
        Instantiate(respawnTimerTxt, transform.position, Quaternion.Euler(45, 0, 0));
        transform.position = new Vector3(-100, transform.position.y, -100);
        yield return new WaitForSeconds(5);
        transform.position = respawnPoint.position;
        didCoroutineStart = false;
    }
}
