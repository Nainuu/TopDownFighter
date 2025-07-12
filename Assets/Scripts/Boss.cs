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

        float speed = aIPath.desiredVelocity.magnitude;
        animator.SetFloat("Enspeed", speed);
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        BossHealth -= damage;
        BossHealth = Mathf.Clamp(BossHealth, 0, 9999);

        // Uncomment this if you have an AudioManager:
        // FindFirstObjectByType<AudioManager>()?.Play("EnDamage");

        if (bossHealthUI != null)
        {
            bossHealthUI.SetHealth((int)BossHealth);
        }

        Debug.Log("Boss took damage, health now: " + BossHealth);

        if (BossHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;

        isDead = true;

        if (animator != null)
        {
            // animator.SetTrigger("enDie"); // Optional: add a death animation
        }

        aIPath.canMove = false;
        aIPath.enabled = false;

        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

        Destroy(bossObject, 0.5f); // Optional: destroy the boss visuals
    }
}
