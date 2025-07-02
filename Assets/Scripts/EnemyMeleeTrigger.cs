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
        Enemy enemy = GetComponent<Enemy>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasAttacked)
        {
            hasAttacked = true;

            // Access PlayerHealth script and damage player
            PlayerController PlayerController = other.GetComponent<PlayerController>();
            if (PlayerController != null)
            {
                PlayerController.TakeDamage(damage);
                if (enemy)
                {   
                    animator.SetTrigger("MeleeAttack");
                }
                Debug.Log("Enemy melee attack hit the player!");
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            hasAttacked = false; // Reset for next attack
            animator.SetTrigger("MeleeOff");
        }
    }
}
