using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class GameManager : MonoBehaviour
{
    public GameObject EquipmentPanel;
    public GameObject CharacterPanel;
    public GameObject GameOverviewPanel;

    // Add a field for PlayerControls
    public InputSystem_Actions PlayerControls;

    void Start()
    {
        GameOverviewPanel.SetActive(true);
    }

    void Update()
    {

    }

    public void ToggleEquipmentPanel()
    {
        EquipmentPanel.SetActive(!EquipmentPanel.activeSelf);
        CharacterPanel.SetActive(false);
        GameOverviewPanel.SetActive(false);
    }
    public void ToggleCharacterPanel()
    {
        CharacterPanel.SetActive(!CharacterPanel.activeSelf);
        EquipmentPanel.SetActive(false);
        GameOverviewPanel.SetActive(false);
    }
    public void ToggleGameOverviewPanel()
    {
        GameOverviewPanel.SetActive(!GameOverviewPanel.activeSelf);
        EquipmentPanel.SetActive(false);
        CharacterPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("trying to quit");
        Application.Quit();
    }
    void Awake()
    {
        PlayerControls = new InputSystem_Actions();
        PlayerControls.Enable();

        // // Link to GameManager
        // GameManager gm = FindObjectOfType<GameManager>();
        // if (gm != null)
        // {
        //     gm.PlayerControls = PlayerControls;
        // }
    }

    public void OpenNewGame()
    {
        if (PlayerControls != null)
        {
            Debug.Log("Disposing PlayerControls before loading GameScene");
            PlayerControls.Dispose();
            PlayerControls = null;
        }
        SceneManager.LoadScene("GameScene");
    }
    public void OpenSettings()
    {
        SceneManager.LoadScene("SettingsScene");
    }
    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
