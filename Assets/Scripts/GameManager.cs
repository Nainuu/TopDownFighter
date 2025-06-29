using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject EquipmentPanel;
    public GameObject CharacterPanel;
    public GameObject GameOverviewPanel;

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

    public void OpenNewGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OpenSettings()
    {
        SceneManager.LoadScene("SettingsScene");
    }
}
