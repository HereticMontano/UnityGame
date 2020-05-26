using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Cherry"))
                GetComponentInChildren<FootController>().cantJumps = 2;
        }
    }
}
