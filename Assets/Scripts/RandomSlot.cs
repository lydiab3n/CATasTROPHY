using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSlot : MonoBehaviour
{

    public Sprite[] sprites;
    public float stopTime;
    private bool isSpinning = false;
    void Update()
    {
        if (isSpinning)
        {
            RandomingImage();
        }

    }

    void RandomingImage()
    {
        gameObject.GetComponent<UnityEngine.UI.Image>().sprite = sprites[Random.Range(0, sprites.Length)];
    }

    void EndRand()
    {
        enabled = false;
    }

    public void StopRand()
    {

        if (isSpinning)
        {
            StartCoroutine(StopAfterDelay());
        }

    }
    IEnumerator StopAfterDelay()
    {
        yield return new WaitForSeconds(stopTime);
        isSpinning = false;
    }
    public void StartRand()
    {
        isSpinning = true;
    }
}