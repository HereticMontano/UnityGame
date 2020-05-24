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

        private BoxCollider2D box;
        private int cantJumps;
        private void Awake()
        {
            box = GetComponent<BoxCollider2D>();
        }

        public bool IsGround
        {
            get
            {
                //Debug.DrawRay(box.bounds.max, Vector2.down * 21, Color.red, 1);
                //Debug.DrawRay(box.bounds.min, Vector2.down * 21, Color.green, 1);

                RaycastHit2D hitRight = Physics2D.Raycast(box.bounds.max, Vector2.down, 2, groundLayer);
                RaycastHit2D hitLeft = Physics2D.Raycast(box.bounds.min, Vector2.down, 2, groundLayer);
                if (hitRight.collider != null || hitLeft.collider != null)
                {
                    cantJumps = 2;
                    return true;
                }

                return false;
            }
        }

        public bool HitWall
        {
            get
            {
                //Debug.DrawRay(box.bounds.min, Vector2.left * 21, Color.green, 1);
                //Debug.DrawRay(box.bounds.max, Vector2.right * 21, Color.red, 1);

                RaycastHit2D hitRight = Physics2D.Raycast(box.bounds.max, Vector2.right, 2, groundLayer);
                RaycastHit2D hitLeft = Physics2D.Raycast(box.bounds.min, Vector2.left, 2, groundLayer);
                return hitRight.collider == null && hitLeft.collider == null;
            }
        }

        public void Jump(float jumpForce)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && (IsGround || cantJumps > 0))
            {
                if (cantJumps > 0)
                {
                    cantJumps--;
                    mainBody.velocity = Vector2.up * jumpForce;
                }
            }
        }
    }
}
