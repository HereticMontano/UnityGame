using System.Linq;
using UnityEngine;

public class MoveCharacterController : MonoBehaviour
{

    public float speed = 0.4f;
    public float jumpForce = 10f;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.5f;

    public LayerMask groundLayer;

    private Rigidbody2D playerRb;
    private float movement;

    private bool isMovingRight;
    private bool isJumping = false;
    private int cantJumps;
    private bool IsGround
    {
        get
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 21, groundLayer);
            if (hit.collider != null)
            {
                isJumping = false;
                cantJumps = 2;
                return true;
            }

            return false;
        }
    }

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
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

        //TODO: Mover esto a fixedUpdate (pero la key presionada se tiene que registrar en update)
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
        if (Input.GetKeyDown(KeyCode.UpArrow) && (IsGround || isJumping))
        {
            if (cantJumps > 0)
            {
                cantJumps--;
                isJumping = true;
                playerRb.velocity = Vector2.up * jumpForce;
            }
        }

        if (playerRb.velocity.y < 0)
        {
            playerRb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (playerRb.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow))
        {
            playerRb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void Move()
    {
        playerRb.velocity = new Vector2(speed * movement, playerRb.velocity.y);
    }

    private void ManageAnimation()
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
