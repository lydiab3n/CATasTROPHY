using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System;
public class NPCInteraction : MonoBehaviour
{
    public GameOverPanel over;
    public GameObject over2;
    public VoiceController vc;
    public SlotMachineManager mg;
    public PlayerController pc;
    private String text_cut ="You have obtained the axe! You can now cut trees by saying 'cut'.";
    private String text_dig= "You have obtained the shovel! You can now dig by saying 'dig'.";
    private String text_fly = "You have obtained the wings! You can now fly by saying 'fly'.";
    private String text_break = "You have obtained the hammer! You can now break walls by saying 'break'.";
    [SerializeField] public TMP_Text label;
    [SerializeField] private TMP_Text auraLabel;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            Debug.Log("Collision with NPC");
            if (!mg.chanceUsed) over.GameOver();
            else over2.SetActive(true);
                        
        }
        
        if (collision.gameObject.CompareTag("axe"))
        {
            Debug.Log("Collision with axe");
            collision.gameObject.SetActive(false);
            vc.hasAxe = true;
            StartCoroutine(TypeWriterEffect(text_cut));
        }
        if (collision.gameObject.CompareTag("shovel"))
        {
            Debug.Log("Collision with shovel");
            collision.gameObject.SetActive(false);
            vc.hasShovel = true;
            StartCoroutine(TypeWriterEffect(text_dig));
        }
        if (collision.gameObject.CompareTag("wing"))
        {
            Debug.Log("Collision with wing");
            collision.gameObject.SetActive(false);

            vc.hasWings = true;
            StartCoroutine(TypeWriterEffect(text_fly));
        }
        if (collision.gameObject.CompareTag("hammer"))
        {
            Debug.Log("Collision with hammer");
            collision.gameObject.SetActive(false);
            vc.hasHammer = true;
            StartCoroutine(TypeWriterEffect(text_break));
        }
        if(collision.gameObject.CompareTag("aura"))
        {
            pc.auraPoints += 1; 
            auraLabel.text = "Aura Points: " + (pc.auraPoints).ToString();
           collision.gameObject.SetActive(false);
            Debug.Log("Aura Points: " + pc.auraPoints);
        }
        if(collision.gameObject.CompareTag("wifey"))
        {
            SceneManager.LoadScene("ending");
        }

        if (collision.gameObject.CompareTag("checkpoint"))
        {
            pc.lastPosition = collision.gameObject.transform.position;
            collision.gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("audio"))
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("Collision with audio");
        }
    }
    private IEnumerator TypeWriterEffect(string txt)
    {
        label.text = "";

        for (int i = 0; i <= txt.Length; i++)
        {
            label.text = txt.Substring(0, i);
            yield return new WaitForSeconds(0.05f);
        }

        //delay before clearing
        yield return new WaitForSeconds(3f);
        label.text = "";
    }
}
