using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameOverPanel over;
    public VoiceController vc;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            Debug.Log("Collision with NPC");
            over.GameOver();
        }
        if (collision.gameObject.CompareTag("axe"))
        {
            Debug.Log("Collision with axe");
            collision.gameObject.SetActive(false);
            vc.hasAxe = true;
        }
        if (collision.gameObject.CompareTag("shovel"))
        {
            Debug.Log("Collision with shovel");
            collision.gameObject.SetActive(false);
            vc.hasShovel = true;
        }
        if (collision.gameObject.CompareTag("wing"))
        {
            Debug.Log("Collision with wing");
            collision.gameObject.SetActive(false);

            vc.hasWings = true;
        }
        if (collision.gameObject.CompareTag("hammer"))
        {
            Debug.Log("Collision with hammer");
            collision.gameObject.SetActive(false);
            vc.hasWings = true;
        }
    }
}
