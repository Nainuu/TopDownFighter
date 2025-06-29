using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public GameObject SettingsPanel;

    private int currentVolumeIndex = 1; // 0 = Mute, 1 = Medium, 2 = High
    private int currentDifficultyIndex = 1; // 0 = Easy, 1 = Medium, 2 = Hard
    private int currentLanguageIndex = 0; // 0 = English, 1 = Urdu, etc.

    private readonly float[] volumeLevels = { 0f, 0.5f, 1f };
    private readonly string[] difficultyLevels = { "Easy", "Medium", "Hard" };
    private readonly string[] languageCodes = { "en", "ur" };

    void Start()
    {
        SettingsPanel.SetActive(true);

        // Load saved settings
        currentVolumeIndex = PlayerPrefs.GetInt("volumeIndex", 1);
        currentDifficultyIndex = PlayerPrefs.GetInt("difficultyIndex", 1);
        currentLanguageIndex = PlayerPrefs.GetInt("languageIndex", 0);

        ApplyVolume();
    }

    public void QuitGame()
    {
        Debug.Log("Trying to quit");
        Application.Quit();
    }

    public void OpenNewGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Volume()
    {
        currentVolumeIndex = (currentVolumeIndex + 1) % volumeLevels.Length;
        ApplyVolume();
    }

    private void ApplyVolume()
    {
        float volume = volumeLevels[currentVolumeIndex];
        AudioListener.volume = volume;
        PlayerPrefs.SetInt("volumeIndex", currentVolumeIndex);
        PlayerPrefs.SetFloat("volume", volume);

        Debug.Log("Volume set to: " + volume);
    }

    public void Difficulty()
    {
        currentDifficultyIndex = (currentDifficultyIndex + 1) % difficultyLevels.Length;
        PlayerPrefs.SetInt("difficultyIndex", currentDifficultyIndex);
        Debug.Log("Difficulty set to: " + difficultyLevels[currentDifficultyIndex]);
    }

    public void Language()
    {
        currentLanguageIndex = (currentLanguageIndex + 1) % languageCodes.Length;
        PlayerPrefs.SetInt("languageIndex", currentLanguageIndex);
        PlayerPrefs.SetString("languageCode", languageCodes[currentLanguageIndex]);

        Debug.Log("Language set to: " + languageCodes[currentLanguageIndex]);
        // Add localization update logic if needed
    }
}
