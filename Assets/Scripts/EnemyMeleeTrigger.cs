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

            // Access PlayerHealth script and damage player
            PlayerController PlayerController = other.GetComponent<PlayerController>();
            if (PlayerController != null)
            {
                PlayerController.TakeDamage(damage);
                animator.SetTrigger("MeleeAttack");
                Debug.Log("Enemy melee attack hit the player!");
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            hasAttacked = false; // Reset for next attack
            // if (animator != null && animator.gameObject != null)
            // {
                // animator.SetTrigger("MeleeOff");
                Debug.Log("melee off");
            // }
        }
    }
}
