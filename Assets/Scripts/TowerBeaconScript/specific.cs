using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class specific : MonoBehaviour
{
    public GameObject healthObject;
    public GameObject healthObject2;
    public GameObject healthObject3;
    // Start is called before the first frame update
    /*
    void Start()
    {
        BeaconScript healthScript = healthObject.GetComponent<BeaconScript>();
        BeaconScript healthScript2 = healthObject2.GetComponent<BeaconScript>();
        BeaconScript healthScript3 = healthObject3.GetComponent<BeaconScript>();

        int currentHealth1 = healthScript.GetCurrentHealth();
        int currentHealth2 = healthScript2.GetCurrentHealth();
        int currentHealth3 = healthScript3.GetCurrentHealth();
    }
    
    void Update()
    {
        BeaconScript healthScript = healthObject.GetComponent<BeaconScript>();
        BeaconScript healthScript2 = healthObject2.GetComponent<BeaconScript>();
        BeaconScript healthScript3 = healthObject3.GetComponent<BeaconScript>();

        int currentHealth1 = healthScript.GetCurrentHealth();
        int currentHealth2 = healthScript2.GetCurrentHealth();
        int currentHealth3 = healthScript3.GetCurrentHealth();

        if (InterTowerTeleport.towerposition==1&&currentHealth1<=0)
        {
            timerScript.isTimerRunning=false;
            // All objects are destroyed, transition to the next scene
            SceneManager.LoadScene(2);
        }
        else if (InterTowerTeleport.towerposition==2&&currentHealth2<=0)
        {
            timerScript.isTimerRunning=false;
            // All objects are destroyed, transition to the next scene
            SceneManager.LoadScene(2);
        }
        else if (InterTowerTeleport.towerposition==0&&currentHealth3<=0)
        {
            timerScript.isTimerRunning=false;
            // All objects are destroyed, transition to the next scene
            SceneManager.LoadScene(2);
        }
    }*/
}
