using System;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class FrogMoveController : BaseMoveController
    {
        public int CantJumps = 2;

        private bool isJumping;
        private bool goRight;

        private void Start()
        {
            InvokeRepeating("Move", 0, 2);
        }

        private void Update()
        {
            if (rb.velocity == Vector2.zero)
            {
                isJumping = false;
                if (CantJumps <= 0)
                {
                    if (!goRight)
                        GetComponentInChildren<Transform>().rotation = Quaternion.Euler(0, 180, 0);
                    else
                        GetComponentInChildren<Transform>().rotation = Quaternion.Euler(0, 0, 0);

                    goRight = !goRight;
                    CantJumps = 2;
                }
            }

            ManageAnimation();
        }

        private void FixedUpdate()
        {
            BaseFall();
        }


        protected override void Move()
        {
            if (!isJumping)
            {
                rb.velocity = new Vector2(speed * (goRight ? 1 : -1), jumpForce);
                isJumping = true;
                CantJumps--;
            }
        }

        protected override void ManageAnimation()
        {
            if (rb.velocity.y > 0)
                GetComponentInChildren<Animator>().SetBool("IsJumping", true);
            else if (rb.velocity.y < 0)
                GetComponentInChildren<Animator>().SetBool("IsJumping", false);

        }
    }
}
