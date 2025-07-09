using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance;
    [SerializeField] private List<GameObject> rooms;
    private Dictionary<string, GameObject> roomDict = new();
    void Start()
    {

    }

private void Awake()
    {
        if (Instance == null) Instance = this;

        foreach (var room in rooms)
        {
            roomDict[room.name] = room;
            room.SetActive(false); // Start with all rooms off
        }
    }

    public void EnterRoom(GameObject targetRoom)
{
    foreach (var room in roomDict.Values)
        room.SetActive(false);

    if (roomDict.ContainsValue(targetRoom))
        targetRoom.SetActive(true);
    else
        Debug.LogWarning("Room not found in dictionary: " + targetRoom.name);
}
}
