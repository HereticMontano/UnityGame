using System;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class FrogMoveController : BaseMoveController
    {
        public int CantJumps = 2;

        private bool isJumping;
        private bool goRight;
        private int countJumps;
        private void Start()
        {
            InvokeRepeating("Move", 0, 2);
            countJumps = CantJumps;
        }

        private void Update()
        {
            if (rb.velocity == Vector2.zero)
            {
                isJumping = false;
                if (countJumps <= 0)
                {
                    if (!goRight)
                        GetComponentInChildren<Transform>().rotation = Quaternion.Euler(0, 180, 0);
                    else
                        GetComponentInChildren<Transform>().rotation = Quaternion.Euler(0, 0, 0);

                    goRight = !goRight;
                    countJumps = CantJumps;
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
                countJumps--;
            }
        }

        protected override void ManageAnimation()
        {
            if (rb.velocity.y > 0)
                GetComponentInChildren<Animator>().SetBool("IsJumping", true);
            else if (rb.velocity.y <= 0)
                GetComponentInChildren<Animator>().SetBool("IsJumping", false);

        }
    }
}
