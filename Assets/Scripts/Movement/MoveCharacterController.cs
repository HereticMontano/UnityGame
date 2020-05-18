using UnityEngine;

public class MoveCharacterController : BaseMoveController
{
    public float lowJumpMultiplier = 2.5f;

    public LayerMask groundLayer;

    private float movement;
    private bool isMovingRight;
    private int cantJumps;
    private bool IsGround
    {
        get
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 21, groundLayer);
            if (hit.collider != null)
            {
                cantJumps = 2;
                return true;
            }

            return false;
        }
    }

    private void Update()
    {
        movement = Input.GetAxis("Horizontal");

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            isMovingRight = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isMovingRight = true;
        }

        Jump();
        ManageAnimation();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && (IsGround || cantJumps > 0))
        {
            if (cantJumps > 0)
            {
                cantJumps--;
                rb.velocity = Vector2.up * jumpForce;
            }
        }

        Fall();
    }

    private void Fall()
    {
        if (!BaseFall() && rb.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    protected override void Move()
    {
        rb.velocity = new Vector2(speed * movement, rb.velocity.y);
    }

    protected override void ManageAnimation()
    {
        bool isMoving = movement != 0;
        if (isMoving)
        {
            if (isMovingRight)
                transform.rotation = Quaternion.Euler(0, 0, 0);
            else
                transform.rotation = Quaternion.Euler(0, 180, 0);

            GetComponent<Animator>().SetFloat("DirectionX", 1);
        }

        GetComponent<Animator>().SetBool("Moving", isMoving);
    }
}
