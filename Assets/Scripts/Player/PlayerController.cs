using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {

        private Vector2 spawnPoint;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Cherry"))
            {
                GetComponentInChildren<FootController>().cantJumps = 2;
                Destroy(collision.gameObject);
            }
            else if (collision.CompareTag("Spawn"))
            {
                spawnPoint = transform.position;
            }
            else if (collision.CompareTag("Fall"))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2();
                transform.position = spawnPoint;
            }
        }
    }
}
