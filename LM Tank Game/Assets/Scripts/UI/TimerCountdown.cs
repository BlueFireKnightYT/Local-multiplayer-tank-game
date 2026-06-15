using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerCountdown : MonoBehaviour
{
    TextMeshProUGUI timer;

    public int startTime = 300;
    public float remainingTime;

    int minutes;
    int seconds;

    private void Start()
    {
        timer = this.GetComponent<TextMeshProUGUI>();
        remainingTime = startTime;
    }

    private void Update()
    {
        remainingTime -= Time.deltaTime;
        minutes = Mathf.FloorToInt(remainingTime / 60);
        seconds = Mathf.FloorToInt(remainingTime % 60);

        timer.text = minutes.ToString() + ":" + seconds.ToString();

        if (remainingTime <= 0)
        {
            PointCounter.Instance.AssignPointToPlayer();
            SceneManager.LoadScene("WinLose");
        }
    }
}
