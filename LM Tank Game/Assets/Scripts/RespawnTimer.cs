using TMPro;
using UnityEngine;

public class RespawnTimer : MonoBehaviour
{
    int respawnTime = 5;
    float currentRespawnTimer;
    int remainingTimeInt;

    public TextMeshProUGUI text;
    private void Start()
    {
        currentRespawnTimer = respawnTime;
    }
    private void Update()
    {
        currentRespawnTimer -= Time.deltaTime;

        remainingTimeInt = Mathf.CeilToInt(currentRespawnTimer);

        text.text = remainingTimeInt.ToString();

        if (currentRespawnTimer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
