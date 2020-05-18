using Pathfinding;
using UnityEngine;
public class EnemyGFXControll : MonoBehaviour
{
    public AIPath aiPath;

    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (aiPath.desiredVelocity.x <= -0.01f)
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
