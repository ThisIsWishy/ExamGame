using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    // Update is called once per frame
    void Update()
    {
        if (target.position.y > 23.52f && target.position.y < 65.64f)
        {
            transform.position = new Vector3(transform.position.x, target.position.y, -10);
        }
    }
}
