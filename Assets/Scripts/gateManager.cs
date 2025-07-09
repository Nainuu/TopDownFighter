using UnityEngine;
using UnityEngine.Assertions.Must;

public class gateManager : MonoBehaviour
{
    public Animator animator;
    private bool levelPassed = true;  // For testing, set to true
    private bool gateOpened = false;
    [SerializeField] private GameObject targetRoom;
    public RoomManager roomManager;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // && levelPassed && !gateOpened
        if (collision.CompareTag("Player") && !gateOpened)
        {
            OpenGate();
        }
    }

    void OpenGate()
    {
        gateOpened = true;
        animator.SetTrigger("GateOpen");
        Debug.Log("Gate opening...");
        // RoomManager.Instance.EnterRoom(targetRoom);
        // wait 1 second before closing
        Invoke(nameof(CloseGate), 1.0f);
    }

    void CloseGate()
    {
        animator.SetTrigger("gateClose");
        Debug.Log("Gate closing...");
    }
}
