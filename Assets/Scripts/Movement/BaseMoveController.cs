using UnityEngine;

public abstract class BaseMoveController : MonoBehaviour
{
    public float speed = 0.4f;
    public float jumpForce = 10f;

    public float fallMultiplier = 2.5f;
    
    protected Rigidbody2D rb;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected bool BaseFall()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            return true;
        }
        return false;
    }

    protected abstract void Move();

    protected abstract void ManageAnimation();
}
