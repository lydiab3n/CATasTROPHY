using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Globalization;

public class VoiceController : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();

    private PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlayerController>();

        // TODO : add an if to check if jump and stop are already in the dictionary


        actions.Add("jump", () => SetMovement(Vector2.up));
        actions.Add("kill yourself", () => Debug.Log("killed"));
        actions.Add("stop", () => SetMovement(Vector2.zero));
        actions.Add("bridge", () => Bridge());
        actions.Add("break", () => BreakWall());
        actions.Add("cut", () => CutTree());
        actions.Add("dig", () => Dig());

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
    void DestroyClosest(string tagName, float range = 10f)
    {
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag(tagName);
            if (objects.Length == 0)
                return;

            GameObject closest = null;
            float closestDist = Mathf.Infinity;
            Vector3 playerPos = transform.position;

            foreach (GameObject obj in objects)
            {
                float dist = Vector3.Distance(playerPos, obj.transform.position);
                if (dist < closestDist && dist <= range)
                {
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

    void BreakWall()
    {
        DestroyClosest("BreakableWall");
    }

    void CutTree()
    {
        DestroyClosest("Tree");
    }

    void Dig()
    {
        DestroyClosest("Hole");
    }

    void Bridge()
    {
        var bridge = GameObject.Find("Bridge");
        if (bridge != null)
        {
            bridge.GetComponent<Animation>().Play("bridge_anim");
        }
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
