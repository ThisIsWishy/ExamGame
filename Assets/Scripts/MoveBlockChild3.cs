using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MoveBlockChild3 : MoveBlockParent
{
    [SerializeField] private float speed;
    [SerializeField] private float distance;
    [SerializeField] private float targetTime;
    private float startTargetTime;
    private float startPos;

    void Start()
    {
        startPos = gameObject.transform.position.y;
        startTargetTime = targetTime;
    }

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
        if(gameObject.transform.position.y < startPos+distance)
        {
            transform.position = new Vector2(transform.position.x,transform.position.y + speed * Time.deltaTime);
        }
    }
    void MoveDown()
    {
        if(gameObject.transform.position.y > startPos)
        {
            transform.position = new Vector2(transform.position.x,transform.position.y + -speed * Time.deltaTime);
        }
        if(gameObject.transform.position.y <= startPos)
        {
            targetTime = startTargetTime;
        }
    }
}
