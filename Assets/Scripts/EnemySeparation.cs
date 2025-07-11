using UnityEngine;

public class EnemySeparation : MonoBehaviour
{
    public float separationRadius = 1f;
    public float pushForce = 1f;
    public LayerMask enemyLayer;

    private void FixedUpdate()
    {
        Collider2D[] nearby = Physics2D.OverlapCircleAll(transform.position, separationRadius, enemyLayer);
        foreach (var other in nearby)
        {
            if (other.gameObject != gameObject)
            {
                Vector2 pushDir = (Vector2)(transform.position - other.transform.position);
                transform.position += (Vector3)(pushDir.normalized * pushForce * Time.fixedDeltaTime);
            }
        }
    }
}
