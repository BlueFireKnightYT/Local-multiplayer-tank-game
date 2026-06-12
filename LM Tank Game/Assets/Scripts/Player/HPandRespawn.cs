using UnityEngine;
using UnityEngine.UI;

public class HPandRespawn : MonoBehaviour
{


    public int maxHP = 5;
    int currentHP;

    public Transform respawnPoint;
    public int playerNum;
    [SerializeField] Slider hpBar;

    private void Start()
    {
        currentHP = maxHP;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {

            currentHP--;
            if (currentHP <= 0)
            {
                currentHP = maxHP;
                transform.position = respawnPoint.position;

                //Get the HP script from the other player
                BulletScript bulletScript = other.GetComponent<BulletScript>();
                GameObject otherPlayer = bulletScript.player;
                HPandRespawn otherHpScript = otherPlayer.GetComponent<HPandRespawn>();

                PointCounter.Instance.AddPoint(otherHpScript.playerNum);
            }
            updateHpBar();
            Debug.Log(currentHP);
        }
    }

    private void updateHpBar()
    {
        hpBar.value = currentHP;
    }
}
