using UnityEngine;
using Pathfinding;

public class EnActivation : MonoBehaviour
{
    private AIPath aiPath;

    private void Awake()
    {
        aiPath = GetComponentInParent<AIPath>();
        aiPath.canMove = false; // Start inactive
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            aiPath.canMove = true; // Enable movement when player is close
        }
    }
}
