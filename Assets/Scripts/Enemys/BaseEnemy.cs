using Pathfinding;
using UnityEngine;


public class BaseEnemy : MonoBehaviour
{
    public float lifePoints = 1;

    private void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        lifePoints -= damage;
        if (lifePoints <= 0)
        {
            SetDeat();
        }
    }

    private void SetDeat()
    {
        GetComponentInChildren<Animator>().SetBool("IsDead", true);
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<AIPath>().isStopped = true;
    }
}

