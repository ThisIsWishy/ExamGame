using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ColorChange : MonoBehaviour
{
    private bool leftPressed = false;
    private bool rightPressed = false;
    private bool jumpPressed = false;
    private bool shootPressed = false;
    private bool playerLeft;
    private bool playerRight;
    private bool playerJump;
    private bool playerShoot;
    private float targetTime = 2f;
    public GameObject keys;
    public Color newColor;
    
    [SerializeField ]private SpriteRenderer sb;
    void Update()
    {
        playerLeft = Input.GetKey(KeyCode.A);
        playerRight = Input.GetKey(KeyCode.D);
        playerJump = Input.GetKey(KeyCode.W);
        playerShoot = Input.GetKey(KeyCode.Space);
        if (playerLeft && gameObject.name == "A Square")
        {
            sb.color = newColor;
        }
        else if (playerLeft)
        {
            leftPressed = true;
        }
        if (playerRight && gameObject.name == "D Square")
        {
            sb.color = newColor;
        }
        else if (playerRight)
        {
            rightPressed = true;
        }
        if (playerJump && gameObject.name == "W Square")
        {
            jumpPressed = true;
            sb.color = newColor;
        }
        if (playerShoot && gameObject.name == "Space Square")
        {
            sb.color = newColor;
        }
        else if (playerShoot)
        {
            shootPressed = true;
        }
        if(leftPressed && rightPressed && jumpPressed && shootPressed)
        {
            targetTime -= Time.deltaTime;
            if (targetTime <= 0.0f)
            {
                keys.SetActive(false);
            }
        } 
    }
}
