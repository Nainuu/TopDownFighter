using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance;
    private List<string> clearedRooms = new List<string>();
    public LevelBlocker level1Blocker;
    public LevelBlocker level2Blocker;

    public GameObject UIManager;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject); // Ensure only one instance exists
    }


    public void EnterRoom(GameObject targetRoom)
    {
        if (targetRoom == null)
        {
            Debug.LogWarning("Target room is null!");
            return;
        }
        UIManager.GetComponent<UiManagment>().ShowRoomNumber(targetRoom.name);
        var logic = targetRoom.GetComponent<RoomLogic>();
        if (logic != null)
            logic.OnRoomEnter();
        else
            Debug.LogWarning("No RoomLogic script found on target room.");
    }
    public void RoomCleared(string roomName)
    {
        Debug.Log("Room cleared: " + roomName);

        if (!clearedRooms.Contains(roomName))
        {
            clearedRooms.Add(roomName);
            Debug.Log("Added to cleared rooms: " + roomName);
        }
        else
        {
            Debug.LogWarning("Room already cleared: " + roomName);
        }

        // Check Level 1: Room1, Room2, Room3
        if (clearedRooms.Contains("Room1") &&
            clearedRooms.Contains("Room2") &&
            clearedRooms.Contains("Room3") &&
            !level1Blocker.isCleared)
        {
            Debug.Log("Level 1 cleared");
            level1Blocker.isCleared = true;
            level1Blocker.gameObject.SetActive(false);
            UIManager.GetComponent<UiManagment>().ShowRoomUnlockDisplay();
        }

        // Check Level 2: Room4, Room5
        if (clearedRooms.Contains("Room4") &&
            clearedRooms.Contains("Room5") &&
            !level2Blocker.isCleared)
        {
            Debug.Log("Level 2 cleared");
            level2Blocker.isCleared = true;
            level2Blocker.gameObject.SetActive(false);
            UIManager.GetComponent<UiManagment>().ShowRoomUnlockDisplay();
        }
    }


}
