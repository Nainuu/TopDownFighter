using System;
using UnityEngine;

[Serializable]
public class UiManagment : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject winMenu;
    public GameObject startMenu;
    void Start()
    {
        // Show the start menu at the beginning
        ShowStartMenu();
    }

    // Update is called once per frame
    void Update()
    {

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
        Time.timeScale = 0f; // Pause the game
    }
}
