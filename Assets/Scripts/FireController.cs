using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject prefabBullet;
    public float speedBullet;

    private GameObject lastBulletFire;
    public void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            lastBulletFire = Instantiate(prefabBullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
    }

    public void FixedUpdate()
    {
        if(lastBulletFire != null)
        {
            var bRb = lastBulletFire.GetComponent<Rigidbody2D>();
            if(bRb.velocity == Vector2.zero)
            {
                if(transform.rotation.y == 0)
                    bRb.velocity = Vector2.right * speedBullet;
                else
                    bRb.velocity = Vector2.left * speedBullet;
            }
        }
    }
}
