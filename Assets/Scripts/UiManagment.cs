using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

[Serializable]
public class UiManagment : MonoBehaviour
{
    [Header("Menus")]
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject winMenu;
    public GameObject startMenu;

    [Header("Room UI")]
    public GameObject roomNoDisplay;
    public GameObject RoomLockDisplay;
    public GameObject RoomUnlockDisplay;

    [Header("Input")]
    public InputSystem_Actions PlayerControls;
    public InputAction Pause;


    private void Awake()
    {
        PlayerControls = new InputSystem_Actions();
    }

    private void Start()
    {
        // Show the start menu at the beginning
        ShowStartMenu();
    }

    private void OnEnable()
    {
        Pause = PlayerControls.Player.Pause;
        Pause.Enable();
        Pause.performed += OnPause;
    }

    private void OnDisable()
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
        Time.timeScale = 0f;
    }

    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
        startMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 0f;
        PlayerControls.Player.Disable();
        PlayerControls.UI.Enable();

        FindFirstObjectByType<AudioManager>()?.Play("UiAnimation");
    }

    public void ResumeGame()
    {
        PlayerControls.Player.Enable();
        PlayerControls.UI.Disable();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        FindFirstObjectByType<AudioManager>()?.Play("UiAnimation");
    }

    public void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        pauseMenu.SetActive(false);
        startMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ShowWinMenu()
    {
        winMenu.SetActive(true);
        pauseMenu.SetActive(false);
        startMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ShowRoomNumber(string roomNumber)
    {
        roomNoDisplay.SetActive(true);
        roomNoDisplay.GetComponentInChildren<TextMeshProUGUI>().text = roomNumber;
    }

    public void ShowRoomLockDisplay()
    {
        RoomLockDisplay.SetActive(true);
        RoomUnlockDisplay.SetActive(false);
        Invoke(nameof(HideRoomLockDisplay), 3f);
    }

    public void ShowRoomUnlockDisplay()
    {
        RoomUnlockDisplay.SetActive(true);
        RoomLockDisplay.SetActive(false);
        Invoke(nameof(HideRoomUnlockDisplay), 3f);
    }

    private void HideRoomLockDisplay()
    {
        RoomLockDisplay.SetActive(false);
    }

    private void HideRoomUnlockDisplay()
    {
        RoomUnlockDisplay.SetActive(false);
    }
}
