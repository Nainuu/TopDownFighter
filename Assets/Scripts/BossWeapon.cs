using System;
using UnityEngine;

[Serializable]
public class BossWeapon : MonoBehaviour
{
    public int damage = 10;
    public bool hasAttacked = false;
    public Animator animator;
    public Boss boss;

    void Start()
    {
        boss = GetComponent<Boss>();
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

                if (animator != null)
                {
                    string selectedAttack = GetAttackBasedOnHealth(playerController);
                    animator.SetTrigger(selectedAttack);

                    Debug.Log($"Boss used {selectedAttack} based on player's health.");
                }
                else
                {
                    Debug.LogWarning("Animator is missing or destroyed.");
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hasAttacked = false;
        }
    }

    private string GetAttackBasedOnHealth(PlayerController player)
    {
        float healthPercent = (float)player.currentHealth / player.MaxHealth;

        if (healthPercent > 0.66f)
            return "Attk2"; // Strong attack
        else if (healthPercent < 0.33f)
            return "Attk3"; // Finisher
        else
            return "Attk1"; // Normal attack
    }
}
