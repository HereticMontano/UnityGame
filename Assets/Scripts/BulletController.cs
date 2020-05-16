using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float lifeTime;

    public float damage = 1;

    public float speedBullet = 200;


    private Rigidbody2D rb;

    private void Start()
    {
        var player = FindObjectsOfType<GameObject>().FirstOrDefault(x => x.CompareTag("Player"));
        
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (player.transform.rotation.y == 0 ? Vector2.right : Vector2.left) * speedBullet;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeTime > 0)
            lifeTime -= Time.deltaTime;
        else
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<BaseEnemy>().TakeDamage(damage);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<BaseEnemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
        }
    }
}
