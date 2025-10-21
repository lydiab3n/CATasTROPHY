using System.Collections;
using UnityEngine;
using TMPro;  

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private TMP_Text label;
    [SerializeField] private GameObject StartGame;
    [SerializeField] private float delay = 0.05f; //delay between each character
    [SerializeField] private float lineDelay = 1f; //delay between lines
    [SerializeField] private float dialogueDelay = 2f;
    [SerializeField] private VoiceController vc;
    public int deb_or_end = 0; //0 for debut, 1 for end

    void Start()
    {
        StartCoroutine(PlayAllDialogues(deb_or_end));
    }

    private IEnumerator PlayAllDialogues(int i)
    {
        if(i==1){
        yield return StartCoroutine(TypeWriterEffect("Cowcat : My beloved... I went through the heavens and the earth to find you..."));
        yield return new WaitForSeconds(lineDelay);

        yield return StartCoroutine(TypeWriterEffect("Cowcat : And now that I have found you..."));
        yield return new WaitForSeconds(lineDelay);

        yield return StartCoroutine(TypeWriterEffect("Cowcat : I will never let you go..."));

        int aura = PlayerPrefs.GetInt("AuraPoints", 0);
        Debug.Log("Aura Points: " + aura);

        if (aura >= 5)
        {
            yield return StartCoroutine(TypeWriterEffect("Trophywife : My love... You’ve done so much. I am content at last."));
        }
        else
        {
            yield return StartCoroutine(TypeWriterEffect("Trophywife : Ew, no... I can feel the darkness around you."));
        }

            yield return new WaitForSeconds(lineDelay);
        }
        else
        {
        yield return StartCoroutine(TypeWriterEffect("Trophywife : Cowcar... Is that you?"));
        yield return new WaitForSeconds(lineDelay);
        yield return StartCoroutine(TypeWriterEffect("Cowcat : WIFEY!!! I will come save you no matter what!"));
        yield return new WaitForSeconds(lineDelay);
        StartGame.SetActive(true);
        }
        
    }

    private IEnumerator TypeWriterEffect(string txt)
    {
        label.text = "";

        for (int i = 0; i <= txt.Length; i++)
        {
            label.text = txt.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
    }
}
