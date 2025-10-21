using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class SlotMachineManager : MonoBehaviour
{
    public GameObject panel;
    public RandomSlot[] slots;
    //public Button startButton;
    public Slider lever;
    public float spinDuration = 5f;
    private float resultDisplayTime  = 2f; //time to show the result before action

    [Header("win settings")]
    public int winningIndex = 0; // index of the sprite considered a win

    private bool isSpinning = false;
    public bool chanceUsed = false;
    public PlayerController player;
    public SliderLimitation leverLim;
    


    void Start()
    {
        lever.onValueChanged.AddListener(delegate { startSpinning(); });
        //startButton.onClick.AddListener(startSpinning);
    }
    public void startSpinning()
    {
        if (!isSpinning)
        {
            isSpinning = true;
            //startButton.interactable = false;
            foreach (RandomSlot slot in slots)
            {
                slot.StartRand();
            }
            StartCoroutine(stopSlotsAfterDelay());
        }
    }

    IEnumerator stopSlotsAfterDelay()
    {
        yield return new WaitForSeconds(spinDuration);
        foreach (RandomSlot slot in slots)
        {
            slot.StopRand();
        }
        yield return new WaitForSeconds(resultDisplayTime); // delay
        float maxStopTime = 0f;
        foreach (RandomSlot slot in slots)
        {
            if (slot.stopTime > maxStopTime)
                maxStopTime = slot.stopTime;
        }
    
    yield return new WaitForSeconds(maxStopTime + 0.5f);
        checkWinCondition();
    }
    void checkWinCondition()
    {
        //check if all slots have the same sprite as the first one
        Sprite first = slots[0].GetComponent<Image>().sprite;
        bool allMatch = true;

        foreach (var slot in slots)
        {
            if (slot.GetComponent<Image>().sprite != first)
            {
                allMatch = false;
                break;
            }
        }

        if (!allMatch) //#TODO CHANGE
        {
            Debug.Log("you win! second chance!");
            //PlayerPrefs.SetInt("SecondChance", 1);
            panel.SetActive(false);
            leverLim.reset = true;
            lever.value = 0;
            chanceUsed = true;
            player.respawnAtCheckpoint();
        }
        else
        {
            Debug.Log("boo loser. restarting game.");
            //PlayerPrefs.SetInt("SecondChance", 0);
            StartCoroutine(ReloadAfterDelay());

        }


    }
     IEnumerator ReloadAfterDelay()
    {
        //small delay so the player can see the losing screen
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("main");
    }
     
}
