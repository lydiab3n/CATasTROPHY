using UnityEngine;

public class HideButton : MonoBehaviour
{


    //public UnityEngine.UI.Button self;
    public GameObject self;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Disable()
    {
        self.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
