using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverPanel : MonoBehaviour
{
    public GameObject panel;

    public void GameOver()
    {
        panel.SetActive(true);
        PlayerPrefs.SetString("ReturnScene", SceneManager.GetActiveScene().name); // saves current scene to return to if we win slot machine

    }

    public void moveToSlotMachine()
    {
        PlayerPrefs.SetString("ReturnScene", SceneManager.GetActiveScene().name); // saves current scene to return to if we win slot machine
        SceneManager.LoadScene("SlotMachine", LoadSceneMode.Single);
    }
}
