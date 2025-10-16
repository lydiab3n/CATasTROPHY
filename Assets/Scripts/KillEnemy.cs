using UnityEngine;

public class KillEnemy : MonoBehaviour
{

    public GameObject self;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 

    public void Kill() {
        self.SetActive(false);
    }

   
}
