using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSlot : MonoBehaviour
{

    public Sprite[] sprites;
    public float StopTime;

    void Update()
    {
        RandomingImage();

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

        Invoke("EndRand", StopTime);

    }
    public void StartRand()
    {

        enabled = true;
    }
}