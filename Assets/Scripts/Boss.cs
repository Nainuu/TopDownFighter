using System;
using UnityEngine;
using Pathfinding;

[Serializable]
public class Boss : MonoBehaviour
{
    public Animator animator;
    public float BossHealth = 100f;
    public AIPath aIPath;
    public bool isDead = false;
    public GameObject bossObject;
    public BossHealth bossHealthUI;
    public GameObject deathEffect;
    public Animator dieAnimator;
    public GameObject BossMainObject;
    public PlayerController playerController;
    private int healthReward = 75;

    void Start()
    {
        if (bossHealthUI != null)
        {
            bossHealthUI.SetMaxHealth((int)BossHealth);
        }
    }

    void Update()
    {
        if (aIPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-3.3f, 3.3f, 3.3f);
        }
        else if (aIPath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(3.3f, 3.3f, 3.3f);
        }
        if (isDead) return;
        float speed = aIPath.desiredVelocity.magnitude;
        animator.SetFloat("Speed", speed);
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        BossHealth -= damage;
        BossHealth = Mathf.Clamp(BossHealth, 0, 9999);

        // Uncomment this if you have an AudioManager:
        FindFirstObjectByType<AudioManager>()?.Play("EnDamage");

        if (bossHealthUI != null)
        {
            bossHealthUI.SetHealth((int)BossHealth);
        }

        Debug.Log("Boss took damage, health now: " + BossHealth);

        if (BossHealth <= healthReward && healthReward > 0)
    {
        if (playerController != null)
        {
            playerController.gainHealth(10); // Heal 10 or any value you want
            Debug.Log("Player healed on boss threshold: " + healthReward);
        }

        healthReward -= 25; // Set next threshold down
    }

        if (BossHealth <= 10)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;

        isDead = true;
        if (deathEffect != null)
        {
            deathEffect.SetActive(true);
            FindFirstObjectByType<AudioManager>()?.Play("BossDeath");

            // if (dieAnimator != null)
            // {
            //     dieAnimator.SetTrigger("BossDied"); // Optional: add a death animation
            // }
            Destroy(deathEffect, 1.4f);
            
        }


        aIPath.canMove = false;
        aIPath.enabled = false;

        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        bossObject.SetActive(false);
        Destroy(BossMainObject, 2f); // Optional: destroy the boss visuals
        bossHealthUI.gameObject.SetActive(false);
    }
}
