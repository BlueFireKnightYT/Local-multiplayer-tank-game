using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartMatch()
    {
        SceneManager.LoadScene("Gameplay Scene");
        PlayerInputManager.instance.DisableJoining();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
