using UnityEngine;
using TMPro;

public class DiffultyManager : MonoBehaviour
{
    public TMP_Dropdown difficultyDropdown;

    void Start()
    {
        int savedDifficulty = PlayerPrefs.GetInt("Difficulty", 7);
        difficultyDropdown.value = savedDifficulty;
        difficultyDropdown.RefreshShownValue();
    }

    public void SetDifficulty(int index)
    {
        PlayerPrefs.SetInt("Difficulty", index);
    }
}
