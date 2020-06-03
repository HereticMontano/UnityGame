using Cinemachine;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {

        public GameObject weaponsSystem;

        private Vector2 spawnPoint;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Cherry"))
                GetComponentInChildren<FootController>().cantJumps = 2;
            else if (collision.CompareTag("Cristal"))
                weaponsSystem.SetActive(true);
            else if (collision.CompareTag("Spawn"))
                spawnPoint = transform.position;
            else if (collision.CompareTag("Fall") || collision.CompareTag("Enemy"))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2();
                transform.position = spawnPoint;
            }
            else if(collision.CompareTag("Box"))
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            else if (collision.CompareTag("Shuttle"))
            {
                gameObject.SetActive(false);

            }
        }
    }
}
