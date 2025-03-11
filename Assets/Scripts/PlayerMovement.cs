using System.Numerics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.linearVelocity = new UnityEngine.Vector2(Input.GetAxis("Horizontal") * speed, 0);

        if(Input.GetKey(KeyCode.Space))
        {
            body.linearVelocity = new UnityEngine.Vector2(body.linearVelocity.x, speed);
        }
    }
}
