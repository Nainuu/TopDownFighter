using System;
using UnityEngine;
using Pathfinding;
using UnityEngine.Animations;

[Serializable]
public class Enemy : MonoBehaviour
{
    public Animator animator;
    public float EnemyHealth = 40f;
    public GameObject deathEffect;
    public AIPath aIPath;
    public bool isDead = false;
    public GameObject enObject;

    void Update()
    {
        if (aIPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(3.3f, 3.3f, 3.3f);
        }
        else if (aIPath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(-3.3f, 3.3f, 3.3f);
        }

        float speed = aIPath.desiredVelocity.magnitude;
        animator.SetFloat("Enspeed", speed);
    }

    public void TakeDamage(int damage)
    {
        EnemyHealth -= damage;
        FindFirstObjectByType<AudioManager>()?.Play("EnDamage");
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
            FindFirstObjectByType<AudioManager>()?.Play("EnDie");


        }

        // Trigger animation if animator is assigned
        if (animator != null)
        {
            animator.SetTrigger("enDie");
        }

        // Delay destruction so animation or effect can play
        aIPath.canMove = false;
        aIPath.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        Destroy(enObject, 0.5f);
        isDead = true;

        EnemyMeleeTrigger meleeTrigger = GetComponentInChildren<EnemyMeleeTrigger>();
        if (meleeTrigger != null)
        {
            meleeTrigger.enabled = false;
        }
        

    }

}
