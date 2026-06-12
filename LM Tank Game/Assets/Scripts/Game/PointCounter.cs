using TMPro;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    public static PointCounter Instance;

    int p1Points;
    int p2Points;
    int p3Points;
    int p4Points;

    [SerializeField] TextMeshProUGUI[] pointCounters;

    public void AddPoint(int player)
    {
        int pointCountersIndex = player - 1;

        if(player == 1)
        {
            p1Points++;
            pointCounters[pointCountersIndex].text = "Player " + pointCountersIndex.ToString() + " Kills: " + p1Points.ToString();
            //Player 1 Kills: 2
        }
        else if(player == 2)
        {
            p2Points++;
            pointCounters[pointCountersIndex].text = "Player " + pointCountersIndex.ToString() + " Kills: " + p2Points.ToString();
        }
        else if(player == 3)
        {
            p3Points++;
            pointCounters[pointCountersIndex].text = "Player " + pointCountersIndex.ToString() + " Kills: " + p3Points.ToString();
        }
        else if(player == 4)
        {
            p4Points++;
            pointCounters[pointCountersIndex].text = "Player " + pointCountersIndex.ToString() + " Kills: " + p4Points.ToString();
        }
    }
}
