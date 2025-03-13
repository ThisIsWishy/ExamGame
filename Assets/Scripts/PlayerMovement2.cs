using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2 : MonoBehaviour
{
    private bool player1Left;
    private bool player1Right;
    private bool isFacingRight = true;
    [SerializeField] private float jumpPower;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    // Update is called once per frame
    void Update()
    {
        player1Left = Input.GetKey(KeyCode.LeftArrow);
        player1Right = Input.GetKey(KeyCode.RightArrow);

        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            rb.linearVelocity = new UnityEngine.Vector2(rb.linearVelocity.x, jumpPower);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new UnityEngine.Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
        Flip();

    }
    void FixedUpdate()
    {
        if(player1Left)
        {
            rb.linearVelocity = new UnityEngine.Vector2(-speed, rb.linearVelocity.y);
        }
        if(player1Right)
        {
            rb.linearVelocity = new UnityEngine.Vector2(speed,rb.linearVelocity.y);
        }
    }
    private void Flip()
    {
        if (isFacingRight && player1Left || !isFacingRight && player1Right)
        {
            isFacingRight = !isFacingRight;
            UnityEngine.Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}

