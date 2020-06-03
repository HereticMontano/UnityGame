using Assets.Scripts.Player;
using UnityEngine;

public class CharacterMoveController : BaseMoveController
{
    public float lowJumpMultiplier = 2.5f;

    private float movement;
    private bool isMovingRight;

    private FootController foot;
    private bool showDialog;

    private void Start()
    {
        foot = GetComponentInChildren<FootController>();
    }

    private void Update()
    {

        movement = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isMovingRight = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isMovingRight = true;
        }

        foot.Jump(jumpForce);
        Fall();
        ManageAnimation();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
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
