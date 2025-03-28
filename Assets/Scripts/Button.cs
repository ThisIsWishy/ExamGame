using System;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Button : MoveBlockParent
{
    public SpriteRenderer sr;
    public float targetTime = 4f;
    // Update is called once per frame
    void Update()
    {
        if(hit)
        {
            targetTime -= Time.deltaTime;
            sr.enabled = false;
        }

        if (targetTime <= 0.0f)
        {
            hit = false;
            sr.enabled = true;
            targetTime = 4f;
        }
        
    }
}
