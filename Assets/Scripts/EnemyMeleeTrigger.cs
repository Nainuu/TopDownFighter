using System;
using UnityEngine;

[Serializable]
public class EnemyMeleeTrigger : MonoBehaviour
{
    public int damage = 10;
    public bool hasAttacked = false;
    public Animator animator;
    public Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasAttacked)
        {
            hasAttacked = true;

            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(damage);

                if (animator != null)  // ✅ Check if animator still exists
                {
                    animator.SetTrigger("MeleeAttack");
                }
                else
                {
                    Debug.LogWarning("Animator is missing or destroyed.");
                }

                Debug.Log("Enemy melee attack hit the player!");
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            hasAttacked = false; // Reset for next attack
            if (animator != null && animator.gameObject != null)
            {
                animator.SetTrigger("MeleeOff");
                Debug.Log("melee off");
            }
        }
    }
}
