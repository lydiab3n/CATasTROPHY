using System.Collections;
using UnityEngine;
using TMPro;  

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private TMP_Text label;
    [SerializeField] private float delay = 0.05f; //delay between each character
    [SerializeField] private float lineDelay = 1f; //delay between lines
    [SerializeField] private float dialogueDelay = 2f;
    [SerializeField] private VoiceController vc;

    void Start()
    {
        StartCoroutine(PlayAllDialogues());
    }

    private IEnumerator PlayAllDialogues()
    {
        yield return StartCoroutine(TypeWriterEffect("My beloved... I went through the heavens and the earth to find you..."));
        yield return new WaitForSeconds(lineDelay);

        yield return StartCoroutine(TypeWriterEffect("And now that I have found you..."));
        yield return new WaitForSeconds(lineDelay);

        yield return StartCoroutine(TypeWriterEffect("I will never let you go..."));

        yield return new WaitForSeconds(lineDelay);
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
