using UnityEngine;
using UnityEngine.SceneManagement;


public class SecondChance : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("SecondChance", 0) == 1)
        {
            Debug.Log("respawning with second chance");
            PlayerPrefs.SetInt("SecondChance", 0); //reset for next time

            //TODO: respawn player at specific location 
            var player = FindFirstObjectByType<PlayerController>();
            if (player != null)
            {
                Debug.Log(player.lastPosition);
                player.respawnAtCheckpoint();
            }
        }
    }
}
