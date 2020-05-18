using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class FrogEnemyController : BaseEnemy
    {
        private Rigidbody2D rb;
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        protected override void SetDeath()
        {
            base.SetDeath();
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
        }
    }
}
