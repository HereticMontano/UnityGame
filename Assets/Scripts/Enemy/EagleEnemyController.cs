using Pathfinding;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EagleEnemyController : BaseEnemy
    {
        public Transform player;

        private AIPath aiPath;
        private void Start()
        {
            aiPath = GetComponent<AIPath>();
            aiPath.isStopped = true;
        }
        
        protected override void SetDeath()
        {
            base.SetDeath();
            aiPath.isStopped = true;
        }

        private void Update()
        {
            if (lifePoints > 0)
            {
                float distance = Vector2.Distance(player.position, transform.position);
                aiPath.isStopped = distance > 400;
            }
        }
    }
}
