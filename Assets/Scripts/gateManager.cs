using UnityEngine;

public class gateManager : MonoBehaviour
{
    public Animator animator;
    private bool levelPassed = true;  // For testing, set to true
    private bool gateOpened = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // && levelPassed && !gateOpened
        if (collision.CompareTag("Player"))
        {
            OpenGate();
        }
    }

    void OpenGate()
    {
        gateOpened = true;
        animator.SetTrigger("GateOpen");
        Debug.Log("Gate opening...");
        Invoke(nameof(CloseGate), 1.0f); // wait 1 second before closing
    }

    void CloseGate()
    {
        animator.SetTrigger("gateClose");
        Debug.Log("Gate closing...");
    }
}
