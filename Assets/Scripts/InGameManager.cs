using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    private InputSystem_Actions PlayerControls;

    private void Awake()
{
    PlayerControls = new InputSystem_Actions();
    PlayerControls.Enable();

    // 👇 Assign to the PlayerController
    var player = FindFirstObjectByType<PlayerController>();
    if (player != null)
    {
        player.PlayerControls = PlayerControls;
    }
}


    public void RestartGame()
    {
        StartCoroutine(RestartAfterCleanup());
    }

    private System.Collections.IEnumerator RestartAfterCleanup()
    {
        Time.timeScale = 1f;

        if (PlayerControls != null)
        {
            Debug.Log("Disabling and disposing PlayerControls before restart");

            PlayerControls.Disable();       // Properly disables bindings
            PlayerControls.Dispose();       // 👈 This is what Unity is expecting
            PlayerControls = null;          // GC-safe
        }

        yield return null;

        Debug.Log("Restarting game scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Game restarted");
    }
    private void OnDestroy()
    {
        if (PlayerControls != null)
        {
            PlayerControls.Disable();
            PlayerControls.Dispose(); // ensure safe GC
            PlayerControls = null;
        }
    }



    public void QuitGame()
    {
        Debug.Log("Game quit");
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;

        if (PlayerControls != null)
        {
            PlayerControls.Disable();
            PlayerControls = null;
        }

        SceneManager.LoadScene("WelcomeScene");
        Debug.Log("Main menu loaded");
    }
}
