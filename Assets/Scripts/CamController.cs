using UnityEngine;

public class CamController : MonoBehaviour
{
    //Script that makes the camera follow the player 
    public Transform player;
    public Vector3 offset = new Vector3(0, 0, -10);

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}
