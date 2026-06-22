using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> activityTexts = new List<TextMeshProUGUI>();
    private int listIndex = -1;

    [SerializeField] private List<GameObject> tankPrefabs = new List<GameObject>();
    private int nextPlayerIndex = 0;

    // Reference to your PlayerInputManager component
    private PlayerInputManager inputManager;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        inputManager = FindAnyObjectByType<PlayerInputManager>();

        if (inputManager != null && tankPrefabs.Count > 0)
        {
            inputManager.playerPrefab = tankPrefabs[0];
        }
    }

    public void OnPlayerJoin(PlayerInput playerInput)
    {
        listIndex++;
        if (listIndex < activityTexts.Count && activityTexts[listIndex] != null)
        {
            activityTexts[listIndex].text = "Active";
        }

        nextPlayerIndex++;

        if (inputManager != null && nextPlayerIndex < tankPrefabs.Count)
        {
            inputManager.playerPrefab = tankPrefabs[nextPlayerIndex];
        }
        else if (inputManager != null)
        {
            inputManager.DisableJoining();
        }
    }

    public void OnPlayerLeave(PlayerInput playerInput)
    {
        if (listIndex >= 0)
        {
            activityTexts[listIndex].text = "Inactive";
            listIndex--;
        }

        if (nextPlayerIndex > 0)
        {
            nextPlayerIndex--;

            if (inputManager != null)
            {
                inputManager.EnableJoining();
                inputManager.playerPrefab = tankPrefabs[nextPlayerIndex];
            }
        }
    }
}
