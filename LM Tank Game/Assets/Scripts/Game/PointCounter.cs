using System.Linq;
using System.Collections.Generic;
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
    List<string> winnerList = new List<string>();
    private void Start()
    {
        Instance = this;
    }
    public void AddPoint(int player)
    {
        int pointCountersIndex = player;

        if(player == 1)
        {
            p1Points++;
            pointCounters[pointCountersIndex - 1].text = "Player " + pointCountersIndex.ToString() + " Kills: " + p1Points.ToString();
            //VOORBEELD: Player 1 Kills: 2
        }
        else if(player == 2)
        {
            p2Points++;
            pointCounters[pointCountersIndex- 1].text = "Player " + pointCountersIndex.ToString() + " Kills: " + p2Points.ToString();
        }
        else if(player == 3)
        {
            p3Points++;
            pointCounters[pointCountersIndex - 1].text = "Player " + pointCountersIndex.ToString() + " Kills: " + p3Points.ToString();
        }
        else if(player == 4)
        {
            p4Points++;
            pointCounters[pointCountersIndex - 1].text = "Player " + pointCountersIndex.ToString() + " Kills: " + p4Points.ToString();
        }
    }

    public void AssignPointToPlayer()
    {
        //Gets all scores from the players
        int[] scores = { p1Points, p2Points, p3Points, p4Points };
        //Gets the highest killcount of all players
        int highestKillCount = scores.Max();

        //Makes a list for all the winners
        List<int> winnerIndexes = new List<int>();

        //Adds all the players with the highest score to the winnersIndexes list
        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i] == highestKillCount && highestKillCount != 0)
            {
                winnerIndexes.Add(i);     
            }
        }

        //Makes a playerPrefs key for every winner and adds the win to that pref
        foreach(int PlayerIndexes in winnerIndexes)
        {
            string winnersPref = PlayerPrefs.GetString("Winners", "");

            int playerIndexForName = PlayerIndexes + 1;

            winnerList.Add("Player " + playerIndexForName.ToString());
            string formattedWinners = string.Join(" & ", winnerList);

            PlayerPrefs.SetString("Winners", formattedWinners);

            string playerPrefsKey = $"Player_{PlayerIndexes}_Wins";

            int currentWins = PlayerPrefs.GetInt(playerPrefsKey, 0);

            PlayerPrefs.SetInt(playerPrefsKey, currentWins += 1);
        }

        //saves the playerprefs
        PlayerPrefs.Save();
    }

}
