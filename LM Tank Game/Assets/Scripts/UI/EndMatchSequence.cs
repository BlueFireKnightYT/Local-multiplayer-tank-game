using TMPro;
using UnityEngine;

public class EndMatchSequence : MonoBehaviour
{
    public TextMeshProUGUI[] winScoreboardItems;
    public TextMeshProUGUI winnerText;
    void Start()
    {
        int player1Wins = PlayerPrefs.GetInt("Player_0_Wins", 0);
        int player2Wins = PlayerPrefs.GetInt("Player_1_Wins", 0);
        int player3Wins = PlayerPrefs.GetInt("Player_2_Wins", 0);
        int player4Wins = PlayerPrefs.GetInt("Player_3_Wins", 0);

        winnerText.text = PlayerPrefs.GetString("Winners", "No One") + " WINS";

        winScoreboardItems[0].text = "Player 1 Wins: " + player1Wins.ToString();
        winScoreboardItems[1].text = "Player 2 Wins: " + player2Wins.ToString();
        winScoreboardItems[2].text = "Player 3 Wins: " + player3Wins.ToString();
        winScoreboardItems[3].text = "Player 4 Wins: " + player4Wins.ToString();

        PlayerPrefs.Save();
    }
}
