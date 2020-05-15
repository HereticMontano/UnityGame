using UnityEngine;
using Pathfinding;
using System;

public class EnemyIA : MonoBehaviour
{

    public Transform target;
    public float speed = 200;
    public float newWeyPointDistance = 1;
    public Transform enemyGFX;

    private Path path;
    private int currentWayPoint = 0;
    private bool reachedEndOfPath = false;
    private Seeker seeker;
    private Rigidbody2D rb;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0, 0.5f);

    }
    void FixedUpdate()
    {
        if (path == null)
            return;

        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
            reachedEndOfPath = false;

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
     
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if (distance < newWeyPointDistance)
            currentWayPoint++;

        if (rb.velocity.x >= 0.01f)
            enemyGFX.rotation = Quaternion.Euler(0, 180, 0);
        else if (rb.velocity.x <= -0.01f)
            enemyGFX.rotation = Quaternion.Euler(0, 0, 0);
    }
    private void OnPathCommplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }
    private void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathCommplete);
    }
    
}
