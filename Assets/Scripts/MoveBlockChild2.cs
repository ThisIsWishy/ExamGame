using System;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MoveBlockChild2 : MoveBlockParent
{
    [SerializeField] private float speed;
    private float targetTime = 4f;

    // Update is called once per frame
    void Update()
    {
        if(hit)
        {
            targetTime -= Time.deltaTime;
            MoveUp();
        }
        if (targetTime <= 0.0f)
        {
            hit = false;
            MoveDown();
        }
    }

    void MoveUp()
    {
        if(gameObject.transform.position.y < 2.11f)
        {
            transform.position = new Vector2(transform.position.x,transform.position.y + speed * Time.deltaTime);
        }
    }
    void MoveDown()
    {
        if(gameObject.transform.position.y > -2.04f)
        {
            transform.position = new Vector2(transform.position.x,transform.position.y + -speed * Time.deltaTime);
        }
        if(gameObject.transform.position.y <= -2.04f)
        {
            targetTime = 4f;
        }
    }
}
