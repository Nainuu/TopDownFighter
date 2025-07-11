using UnityEngine;
using System;

[Serializable]
public class LevelBlocker : MonoBehaviour
{
    public enum Level { Level1, Level2 }
    public Level level;

    public UiManagment uiManager;
    public bool isCleared = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isCleared)
        {
            Debug.Log($"Player collided with blocker for {level}");
            uiManager.ShowRoomLockDisplay();
            FindFirstObjectByType<AudioManager>()?.Play("LvlLocked");

        }
    }
}
