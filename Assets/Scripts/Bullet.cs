using System.Numerics;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
 
public class Bullet : MonoBehaviour
{
    public float life = 3;
    public GameObject prefab;

    void Awake()
    {
        Destroy(gameObject, life);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
