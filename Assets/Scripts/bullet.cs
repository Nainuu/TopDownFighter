using UnityEngine;
using UnityEngine.Rendering;

public class bullet : MonoBehaviour
{
    public float BulletSpeed = 20f;
    public Rigidbody2D rb;
    // Update is called once per frame
    void Start()
    {
        rb.linearVelocity = transform.right * BulletSpeed;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {

            Debug.Log("collision with en detected " + collision.name);
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(10);
            }
            Destroy(gameObject);
        }

        if (collision.CompareTag("Boss"))
        {

            Debug.Log("collision with boss detected " + collision.name);
            Boss boss = collision.GetComponent<Boss>();
            if (boss != null)
            {
                boss.TakeDamage(1);
            }
            Destroy(gameObject);
        }

    }
}   
