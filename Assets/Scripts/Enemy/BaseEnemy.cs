using Pathfinding;
using UnityEngine;


public abstract class BaseEnemy : MonoBehaviour
{
    public float lifePoints = 1;

    public void TakeDamage(float damage)
    {
        lifePoints -= damage;
        if (lifePoints <= 0)
        {
            SetDeath();
        }
    }

    protected virtual void SetDeath()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponentInChildren<Animator>().SetBool("IsDead", true);
    }
}

