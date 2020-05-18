using Pathfinding;
using UnityEngine;


public class BaseEnemy : MonoBehaviour
{
    public float lifePoints = 1;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damage)
    {
        lifePoints -= damage;
        if (lifePoints <= 0)
        {
            SetDeath();
        }
    }

    private void SetDeath()
    {
        GetComponent<Collider2D>().enabled = false;

        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        GetComponentInChildren<Animator>().SetBool("IsDead", true);

        // GetComponent<AIPath>().isStopped = true;
    }
}

