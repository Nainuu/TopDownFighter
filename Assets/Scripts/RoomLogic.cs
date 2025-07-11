using UnityEngine;

public class RoomLogic : MonoBehaviour
{
    public GameObject[] blockers;
    public GameObject[] enemies;

    private bool cleared = false;

    void Start()
    {
        foreach (var blocker in blockers)
        {
            blocker.SetActive(false);
        }

        foreach (var enemy in enemies)
        {
            if (enemy != null)
                enemy.SetActive(false);
        }
    }

    public void OnRoomEnter()
    {
        // Activate blockers when room is entered
        foreach (var blocker in blockers)
            blocker.SetActive(true);
        foreach (var enemy in enemies)
            if (enemy != null)
                enemy.SetActive(true);

        Debug.Log("Entered Room: " + name);
    }

    private void Update()
    {
        if (!cleared && AreAllEnemiesDead())
        {
            cleared = true;
            RoomManager.Instance.RoomCleared(gameObject.name);
            foreach (var blocker in blockers)
                blocker.SetActive(false);

            Debug.Log("Room cleared: " + name);
        }
    }

    private bool AreAllEnemiesDead()
    {
        foreach (var enemy in enemies)
        {
            if (enemy != null)
                return false;
        }

        return true;
    }
    public void roomCleared()
    {
        cleared = true;
        foreach (var blocker in blockers)
            blocker.SetActive(false);
        Debug.Log("Room cleared: " + name);
    }
}
