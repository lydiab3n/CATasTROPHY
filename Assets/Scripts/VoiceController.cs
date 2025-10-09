using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;

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
        }
    }

    void SetMovement(Vector2 direction)
    {
        playerController.voiceMovement = direction;
    }
    void Bridge()
    {
        var bridge = GameObject.Find("Bridge");
        if (bridge != null)
        {
            bridge.GetComponent<Animation>().Play("bridge_anim");
        }
    }

    void BreakWall()
    {
        var wall = GameObject.Find("BreakableWall");
        if (wall != null)
        {
            Destroy(wall);
        }
    }
    }
