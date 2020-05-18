using Pathfinding;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EagleEnemyController : BaseEnemy
    {
        protected override void SetDeath()
        {
            base.SetDeath();
            GetComponentInChildren<Animator>().SetBool("IsDead", true);
            GetComponentInChildren<AIPath>().isStopped = true;
        }
    }
}
