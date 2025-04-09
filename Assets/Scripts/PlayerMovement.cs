using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.UIElements;


public class PlayerMovement : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public bool playerControlActive = true;
    public bool isFacingRight = true;
    private bool playerLeft;
    private bool playerRight;
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
        cam3.enabled = false;
    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    // Update is called once per frame
    void Update()
    {
        playerLeft = Input.GetKey(KeyCode.A);
        playerRight = Input.GetKey(KeyCode.D);
        if (playerControlActive)
        {
            PlayerJump();
            Flip();
        }
    }
    void FixedUpdate()
    {
        if (playerControlActive)
        {
            PlayerMove();
        }

    }
    void PlayerMove()
    {
        
        if(playerLeft)
        {
            rb.linearVelocity = new UnityEngine.Vector2(-speed, rb.linearVelocity.y);
        }
        if(playerRight)
        {
            rb.linearVelocity = new UnityEngine.Vector2(speed,rb.linearVelocity.y);
        }
        //Virker hvis der ingen friction er:
        /*if (!playerLeft && !playerRight && IsGrounded())
        {
            rb.linearVelocity = new UnityEngine.Vector2(0, rb.linearVelocity.y);
        }*/
    }
    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            rb.linearVelocity = new UnityEngine.Vector2(rb.linearVelocity.x, jumpPower);
        }

        if (Input.GetKeyUp(KeyCode.W) && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new UnityEngine.Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
    }
    public void Flip()
    {
        if (isFacingRight && playerLeft && !playerRight || !isFacingRight && playerRight)
        {
            isFacingRight = !isFacingRight;
            UnityEngine.Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    public void EnableControls()
    {
        playerControlActive = true;
    }
    public void DisableControls()
    {
        playerControlActive = false;
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
        if(collision.gameObject.name == "cam3")
        {
            cam1.enabled = false;
            cam2.enabled = false;
            cam3.enabled = true;
            transform.position = new UnityEngine.Vector3(24.84f,16.17f);
            playableDirector.Play();
        }
    }
}