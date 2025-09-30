using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject chatbox;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            Debug.Log("Collision with NPC");
            chatbox.SetActive(true);
            // Do something
        }
    }
}
