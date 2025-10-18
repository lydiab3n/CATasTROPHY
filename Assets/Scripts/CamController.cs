using UnityEngine;

public class CamController : MonoBehaviour
{
    //Script that makes the camera follow the player 
    public Transform player;
    public Vector3 offset = new Vector3(0, 0, -10);
    public int minWidth;
    public int maxWidth;
    public int maxHeight;
    public int minHeight;

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
            if (transform.position.x < minWidth)
            {
                transform.position = new Vector3(minWidth, transform.position.y, transform.position.z);
            }
            if (transform.position.x > maxWidth)
            {
                transform.position = new Vector3(maxWidth, transform.position.y, transform.position.z);
            }
            if (transform.position.y < minHeight)
            {
                transform.position = new Vector3(transform.position.x, minHeight, transform.position.z);
            }
            if (transform.position.y > maxHeight)
            {
                transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
            }
        }
    }
    
}
