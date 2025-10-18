using System;
using System.Collections.Generic;
using System.Globalization;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows.Speech;

public class VoiceController : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();

    private PlayerController playerController;
    public Boolean hasShovel = false;
    public Boolean hasAxe = false;
    public Boolean hasWings = false;
    public Boolean hasHammer = false;
    public AudioLoudnessDetection ald;

    void Start()
    {
        playerController = GetComponent<PlayerController>();

        // TODO : add an if to check if jump and stop are already in the dictionary


        actions.Add("kill yourself", () => Debug.Log("killed"));
        actions.Add("stop", () => SetMovement(Vector2.zero));
        actions.Add("bridge", () => Bridge());
        actions.Add("break", () => BreakWall());
        actions.Add("cut", () => CutTree());
        actions.Add("dig", () => Dig());
        actions.Add("fly", () => Fly());

        string[] keywords = new string[actions.Count];
        actions.Keys.CopyTo(keywords, 0);

        keywordRecognizer = new KeywordRecognizer(keywords);
        keywordRecognizer.OnPhraseRecognized += OnRecognized;
        keywordRecognizer.Start();
    }

    void OnRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Command: " + args.text);
        actions[args.text].Invoke();
    }

    //to avoid error : Error: there already is a keyword recognizer with "stop" as one of its keywords
    void OnDestroy()
    {
        if (keywordRecognizer != null)
        {
            if (keywordRecognizer.IsRunning)
                keywordRecognizer.Stop();
            keywordRecognizer.Dispose();
            Debug.Log("done finished");
        }
    }

    /**
     * Generic function to destroy the closest object with a given tag in front of the player
     * @param tagName The tag of the objects to interact with
     * @param range The maximum range to consider for interaction (10 by default)
     **/
    void DestroyClosest(string tagName, float range = 1000f)
    {
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag(tagName);
            if (objects.Length == 0)
            {
                Debug.Log("objects not found");
                return;
            }

            GameObject closest = null;
            float closestDist = Mathf.Infinity;
            Vector3 playerPos = transform.position;

            foreach (GameObject obj in objects)
            {
                float dist = Vector2.Distance(playerPos, obj.transform.position);
                Debug.Log($"{obj.name} {dist <= range}");
                Debug.Log($"{obj.name} at {obj.transform.position}");

                if (dist < closestDist && dist <= range)
                {
                    Debug.Log("new closest");
                    closestDist = dist;
                    closest = obj;
                }
            }

            if (closest != null)
            {
                Destroy(closest);
                Debug.Log($"Destroyed closest {tagName}");
            }
        }
    }



    void SetMovement(Vector2 direction)
    {
        playerController.voiceMovement = direction;
    }

    public void BreakWall()
    {
        if (hasHammer)
        {
            DestroyClosest("BreakableWall");
            StartCoroutine(Vibrate(1, 1, 1));
        }
    }

    public void CutTree()
    {
        if (hasAxe) { DestroyClosest("Tree"); }
    }

    void Dig()
    {
        if (hasShovel) { DestroyClosest("Hole"); }
    }

    void Bridge()
    {
        var bridge = GameObject.Find("Bridge");
        if (bridge != null)
        {
            bridge.GetComponent<Animation>().Play("bridge_anim");
        }
        Gamepad.current.SetMotorSpeeds(0, 0);

    }


    public void Fly()
    {
        if (hasWings)
        {
            playerController.goUp();
        }
    }

    public IEnumerator Vibrate(float lowFrequency, float highFrequency, float seconds)
    {
        Gamepad.current.SetMotorSpeeds(lowFrequency, highFrequency);
        yield return new WaitForSeconds(seconds);
        Gamepad.current.SetMotorSpeeds(0, 0);
    }



    /*
    void BreakWall()
    {
        var wall = GameObject.Find("BreakableWall");
        if (wall != null)
        {
            Destroy(wall);
        }
    }

    void Dig()
    {
        var hole = GameObject.Find("Hole");
        if (hole != null)
        {
            Destroy(hole);
        }
    }

    void CutTree()
    {
        var hole = GameObject.Find("Tree");
        if (hole != null)
        {
            Destroy(hole);
        }
    }
    */

}
