using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartMatch()
    {
        PlayerPrefs.DeleteKey("Winner");
        SceneManager.LoadScene("Gameplay Scene");
        PlayerInputManager.instance.DisableJoining();
    }

    public void QuitGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
        Debug.Log("Quit");
    }
}
