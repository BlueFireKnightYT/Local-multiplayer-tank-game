using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{

    [SerializeField] private List<TextMeshProUGUI> activityTexts = new List<TextMeshProUGUI>();
    int listIndex = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void OnPlayerJoin()
    {
        listIndex++;
        activityTexts[listIndex].text = "Active";
    }

    public void OnPlayerLeave()
    {
        activityTexts[listIndex].text = "Inactive";
        listIndex--;
    }
}
