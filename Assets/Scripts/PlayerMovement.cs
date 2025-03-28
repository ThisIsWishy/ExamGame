using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class PlayerMovement : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    private bool player1Left;
    private bool player1Right;
    public bool isFacingRight = true;
    [SerializeField] private float jumpPower;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    // Update is called once per frame
    void Update()
    {
        player1Left = Input.GetKey(KeyCode.A);
        player1Right = Input.GetKey(KeyCode.D);

        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            rb.linearVelocity = new UnityEngine.Vector2(rb.linearVelocity.x, jumpPower);
        }

        if (Input.GetKeyUp(KeyCode.W) && rb.linearVelocity.y > 0f)
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
        //Virker hvis der ingen friction er:
        /*if (!player1Left && !player1Right && IsGrounded())
        {
            rb.linearVelocity = new UnityEngine.Vector2(0, rb.linearVelocity.y);
        }*/

    }
    public void Flip()
    {
        if (isFacingRight && player1Left && !player1Right || !isFacingRight && player1Right)
        {
            isFacingRight = !isFacingRight;
            UnityEngine.Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Death"))
        {
            
            transform.position = new UnityEngine.Vector3(-5.09f,-2.73f);
        }
        if(collision.gameObject.name == "cam1")
        {
            if (!cam1.enabled)
            {
                transform.position = new UnityEngine.Vector3(transform.position.x-1.2f,transform.position.y);
            }
            cam1.enabled = true;
            cam2.enabled = false;
        }
        if(collision.gameObject.name == "cam2")
        {
            cam1.enabled = false;
            cam2.enabled = true;
            transform.position = new UnityEngine.Vector3(transform.position.x+0.5f,transform.position.y);
        }
    }
}
