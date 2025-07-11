using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance;
    private List<string> clearedRooms = new List<string>();
    public GameObject level1Blockers;
    public GameObject level2Blockers;

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

        if (clearedRooms.Count >= 3 && clearedRooms.Contains("Room3"))
        {
            Debug.Log("level one cleard");
            level1Blockers.SetActive(false);
        } else if (clearedRooms.Count >= 5 && clearedRooms.Contains("Room5"))
        {
            Debug.Log("level two cleard");
            level2Blockers.SetActive(false);
        }
    }

}
