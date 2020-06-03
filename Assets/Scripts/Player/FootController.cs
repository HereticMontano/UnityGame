using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class FootController : MonoBehaviour
    {
        public LayerMask groundLayer;
        public Rigidbody2D mainBody;
        public int cantJumps;

        private  CapsuleCollider2D capsule;
        private int countJumps;
        private void Awake()
        {
            capsule = GetComponent<CapsuleCollider2D>();
        }

        public bool IsGround
        {
            get
            {
                //Debug.DrawRay(capsule.bounds.max, Vector2.down * 10, Color.red, 1);
                //Debug.DrawRay(capsule.bounds.center, Vector2.down * 10, Color.blue, 1);
                //Debug.DrawRay(capsule.bounds.min, Vector2.down * 10, Color.green, 1);

                RaycastHit2D hitRight = Physics2D.Raycast(capsule.bounds.max, Vector2.down, 10, groundLayer);
                RaycastHit2D hitLeft = Physics2D.Raycast(capsule.bounds.min, Vector2.down, 10, groundLayer);
                RaycastHit2D hitCenter = Physics2D.Raycast(capsule.bounds.center, Vector2.down, 10, groundLayer);
                if (hitCenter.collider != null || hitRight.collider != null || hitLeft.collider != null )
                {
                    countJumps = cantJumps;
                    return true;
                }

                return false;
            }
        }

        public void Jump(float jumpForce)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && (IsGround || countJumps > 0))
            {
                if (countJumps > 0)
                {
                    countJumps--;
                    mainBody.velocity = new Vector2(mainBody.velocity.x, jumpForce);
                }
            }
        }
    }
}
