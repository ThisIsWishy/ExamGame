using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
 
public class Gun2D : MonoBehaviour
{
    public PlayerMovement PlayerScript;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 10;
 
    void Update()
    {
        if (PlayerScript.playerControlActive)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space) && (PlayerScript.isFacingRight == true))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = bulletSpawnPoint.right * bulletSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && PlayerScript.isFacingRight == false)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = -bulletSpawnPoint.right * bulletSpeed;
        }
    }
}
