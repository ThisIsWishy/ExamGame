using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DestroyObject : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
