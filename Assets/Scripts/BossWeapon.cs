using System;
using UnityEngine;

[Serializable]
public class BossWeapon : MonoBehaviour
{
    public Animator animator;
    public int damage = 10;

    private bool isAttacking = false;
    private bool hasHit = false;
    private Collider2D playerInRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isAttacking)
        {
            Debug.Log("Player detected by boss weapon: " + collision.name);
            playerInRange = collision;

            string selectedAttack = ChooseRandomAttack();
            if (selectedAttack == "Attk1")
            {
                animator.SetTrigger("Attk1");
                FindFirstObjectByType<AudioManager>()?.Play("BossAttk1");

            }
            else if (selectedAttack == "Attk2")
            {
                animator.SetTrigger("Attk2");
                FindFirstObjectByType<AudioManager>()?.Play("BossAttk2");
            }
            else
            {
                Debug.LogWarning("No valid attack selected, using default.");
                animator.SetTrigger("Attk1");
            }

            FindFirstObjectByType<AudioManager>()?.Play("PlayerHit");


            StartCoroutine(DelayedAttack());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hasHit = false;
            playerInRange = null;
        }
    }

    private System.Collections.IEnumerator DelayedAttack()
    {
        isAttacking = true;
        hasHit = false;

        yield return new WaitForSeconds(0.15f); // Delay to sync with animation swing

        if (playerInRange != null && !hasHit)
        {
            PlayerController player = playerInRange.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(damage);
                Debug.Log("Player hit by boss during attack window.");
                hasHit = true;
            }
        }

        yield return new WaitForSeconds(0.25f); // Wait for animation to finish (~0.4s total)
        isAttacking = false;
    }

    private string ChooseRandomAttack()
    {
        int random = UnityEngine.Random.Range(0, 2);
        return random == 0 ? "Attk1" : "Attk2";
    }
}
