using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float lifeTime;

    public float damage = 1;
   
    // Update is called once per frame
    void Update()
    {
        if (lifeTime > 0)
            lifeTime -= Time.deltaTime;
        else
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<BaseEnemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if(collision.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
        }
    }
}
