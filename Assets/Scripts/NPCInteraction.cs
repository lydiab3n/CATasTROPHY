using UnityEngine;

public class NPCInteraction : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            Debug.Log("Collision with NPC");
            // Do something
        }
    }
}
