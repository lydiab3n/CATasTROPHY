using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameOverPanel over;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            Debug.Log("Collision with NPC");
            over.GameOver();
        }
    }
}
