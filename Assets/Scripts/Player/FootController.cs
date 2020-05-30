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
                //Debug.DrawRay(box.bounds.max, Vector2.down * 21, Color.red, 1);
                //Debug.DrawRay(box.bounds.min, Vector2.down * 21, Color.green, 1);

                RaycastHit2D hitRight = Physics2D.Raycast(capsule.bounds.max, Vector2.down, 2, groundLayer);
                RaycastHit2D hitLeft = Physics2D.Raycast(capsule.bounds.min, Vector2.down, 2, groundLayer);
                if (hitRight.collider != null || hitLeft.collider != null)
                {
                    countJumps = cantJumps;
                    return true;
                }

                return false;
            }
        }

        public bool HitWall(bool checkRight)
        {
            RaycastHit2D hit;
            if (checkRight)
            {
                hit = Physics2D.Raycast(capsule.bounds.max, Vector2.right, 5, groundLayer);
         //       Debug.DrawRay(box.bounds.max, Vector2.right * 21, Color.red, 1);
            }
            else
            {
                hit = Physics2D.Raycast(capsule.bounds.min, Vector2.left, 5, groundLayer);
           //     Debug.DrawRay(box.bounds.min, Vector2.left * 21, Color.green, 1);
            }
            return hit.collider != null;
        }

        public void Jump(float jumpForce)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && (IsGround || countJumps > 0))
            {
                if (countJumps > 0)
                {
                    countJumps--;
                    mainBody.velocity = Vector2.up * jumpForce;
                }
            }
        }
    }
}
