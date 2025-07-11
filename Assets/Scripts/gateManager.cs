using UnityEngine;
using UnityEngine.Assertions.Must;

public class gateManager : MonoBehaviour
{
    public Animator animator;
    private bool gateOpened = false;
    [SerializeField] private GameObject targetRoom;


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
        RoomManager.Instance.EnterRoom(targetRoom);
        FindFirstObjectByType<AudioManager>()?.Play("DoorEntered");

        
        // wait 1 second before closing
        Invoke(nameof(CloseGate), 1f);
    }

    void CloseGate()
    {
        animator.SetTrigger("gateClose");
    }
}
