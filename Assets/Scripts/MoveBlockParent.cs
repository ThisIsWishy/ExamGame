using System;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MoveBlockParent : MonoBehaviour
{
    public bool hit;
    void Start()
    {
        hit = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            hit = true;
        }
    }

}
