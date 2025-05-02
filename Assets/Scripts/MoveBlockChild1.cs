using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MoveBlockChild1 : MoveBlockParent
{
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        if(hit)
        {
           transform.position = new Vector2(transform.position.x,transform.position.y + -speed * Time.deltaTime);
           Destroy(gameObject,3);
        }
    }
}
