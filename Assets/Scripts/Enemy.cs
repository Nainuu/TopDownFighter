using System;
using UnityEngine;

[Serializable]
public class Enemy : MonoBehaviour
{
    public Animator animator;
    public float EnemyHealth = 40f;
    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        EnemyHealth -= damage;
        Debug.Log("Enemy took damage, health now: " + EnemyHealth);
        if (EnemyHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        if (deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, .1f);
        }

        // Trigger animation if animator is assigned
        if (animator != null)
        {
            animator.SetTrigger("enDie");
        }

        // Delay destruction so animation or effect can play
        Destroy(gameObject, 0.5f);
    }

}
