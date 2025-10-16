using System;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class AudioLoudnessDetection : MonoBehaviour
{

    private AudioClip audioclip;
    public int SampleWindow = 64;
    int k = 0;
    public VoiceController vc;
    public PlayerController player;
    public float value = 0;
    private bool processing;
    public int constant;

    private bool listening=false;
    private float totalLoudness = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //MicrophoneToAudioClip();
    }

    public IEnumerator StartListening()
    {
        listening = true;
        Debug.Log("started Listening");
        MicrophoneToAudioClip();


        while (listening)
        {
            yield return new WaitForSeconds(0.5f);
            value=GetLoudnessFromMicrophone();
            Debug.Log("iteration " + k + " : "+value);
            k++;
            player.goUp(totalLoudness);
        }
     }

    public void StopListening()
    {
        Microphone.End(Microphone.devices[0]);
        listening = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
    }

    public void MicrophoneToAudioClip()
    {
        audioclip = Microphone.Start(Microphone.devices[0], true, 100, AudioSettings.outputSampleRate);
    }


    public float GetLoudnessFromMicrophone()
    {
        int clipPosition = Microphone.GetPosition(Microphone.devices[0]);
        Debug.Log(clipPosition);

        int startPosition = clipPosition - SampleWindow;
        if(startPosition<0) return 0;

        float[] data = new float[SampleWindow];
        audioclip.GetData(data, startPosition);

        
        for (int i = 0; i < data.Length; i++)
        {
            totalLoudness += Mathf.Abs(data[i])*constant;
        }
        return totalLoudness;
    }
}
