using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SlotMachineManager : MonoBehaviour
{
    public GameObject panel;
    public RandomSlot[] slots;
    public Button startButton;
    public float spinDuration = 2f;

    [Header("win settings")]
    public int winningIndex = 0; // index of the sprite considered a win

    private bool isSpinning = false;

    void Start()
    {
        startButton.onClick.AddListener(startSpinning);
    }
    void startSpinning()
    {
        if (!isSpinning)
        {
            isSpinning = true;
            startButton.interactable = false;
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
        yield return new WaitForSeconds(0.1f); // delay

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

        if (allMatch)
        {
            Debug.Log("you win! second chance!");
            PlayerPrefs.SetInt("SecondChance", 1);

        }
        else
        {
            Debug.Log("boo loser. restarting game.");
            PlayerPrefs.SetInt("SecondChance", 0);

        }
        SceneManager.LoadScene("flap");

        
    }
     
}
