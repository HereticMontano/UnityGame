using UnityEngine;

public class MoveCharacterController : MonoBehaviour
{

    public float speed = 0.4f;
    public float jumpForce;
    public float jumpTime;
    
    private Rigidbody2D playerRb;
    private bool isGrounded = true;
    private float movement;
    private float jumpCounter;
    private bool isJumping;

    private bool isMovingRight;

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

        Jump();
        ManageAnimation();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void OnCollisionStay2D(Collision2D col)
    {
        isGrounded = true;
    }

    void OnCollisionEnter2D(Collision2D col) => isGrounded = true;

    void OnCollisionExit2D(Collision2D col) => isGrounded = false;

    private void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            isJumping = true;
            jumpCounter = jumpTime;
            playerRb.velocity = Vector2.up * jumpForce;
        }
       
        if(Input.GetKey(KeyCode.UpArrow) && isJumping)
        {
            if (jumpCounter > 0)
            {
                playerRb.velocity = Vector2.up * jumpForce;
                jumpCounter -= Time.deltaTime;
            }
            else
                isJumping = false;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isJumping = false;
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
