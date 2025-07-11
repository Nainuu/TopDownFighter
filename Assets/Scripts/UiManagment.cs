using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


[Serializable]
public class UiManagment : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject winMenu;
    public GameObject startMenu;
    public InputSystem_Actions PlayerControls;
    public InputAction Pause;
    public GameObject roomNoDisplay;
    public GameObject RoomLockDisplay;
    public GameObject RoomUnlockDisplay;
    public void Awake()
    {
        PlayerControls = new InputSystem_Actions();
    }
    void start()
    {
        // Initialize the UI manager
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        winMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    void OnEnable()
    {
        Pause = PlayerControls.Player.Pause;
        Pause.Enable();
        Pause.performed += OnPause;
    }

    void Start()
    {
        // Show the start menu at the beginning
        ShowStartMenu();
    }
    void OnDisable()
    {
        if (Pause != null)
        {
            Pause.Disable();
            Pause.performed -= OnPause;
        }
    }
    private void OnPause(InputAction.CallbackContext context)
    {
        Debug.Log("Pause button pressed");
        if (pauseMenu.activeSelf)
        {
            ResumeGame();
        }
        else
        {
            ShowPauseMenu();
        }
    }
    public void ShowStartMenu()
    {
        startMenu.SetActive(true);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 0f; // Pause the game
    }
    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
        startMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 0f; // Pause the game
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }
    public void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        pauseMenu.SetActive(false);
        startMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 0f; // Pause the game
    }
    public void ShowWinMenu()
    {
        winMenu.SetActive(true);
        pauseMenu.SetActive(false);
        startMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        Time.timeScale = 0f; // Pause the game
    }
    public void ShowRoomNumber(string roomNumber)
    {
        roomNoDisplay.SetActive(true);
        roomNoDisplay.GetComponentInChildren<TextMeshProUGUI>().text = roomNumber;
    }
    public void ShowRoomLockDisplay()
    {
        RoomLockDisplay.SetActive(true);
        Invoke(nameof(HideRoomLockDisplay), 3f); // Hide after 3 seconds
        RoomUnlockDisplay.SetActive(false);
    }

    private void HideRoomLockDisplay()
    {
        RoomLockDisplay.SetActive(false);
    }
    public void ShowRoomUnlockDisplay()
    {
        RoomUnlockDisplay.SetActive(true);
        Invoke(nameof(HideRoomUnlockDisplay), 3f); // Hide after 3 seconds
        RoomLockDisplay.SetActive(false);
    }
    private void HideRoomUnlockDisplay()
    {
        RoomUnlockDisplay.SetActive(false);
    }
}
