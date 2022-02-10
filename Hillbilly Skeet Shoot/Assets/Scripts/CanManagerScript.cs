using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSwitchScript : MonoBehaviour
{
    public GameObject[] cans;
    [SerializeField] int activeCan = 0;
    // Start is called before the first frame update

    public void WasHit()
    {
        Debug.Log("Message Received");
        switch(activeCan)
        {
            case 0:
            GameManagerScript.score += 1;
            break;

            case 1:
            GameManagerScript.score += 2;
            break;

            case 2:
            GameManagerScript.score += 3;
            break;

            case 3:
            GameManagerScript.score += 4;
            break;

            case 4:
            GameManagerScript.score += 5;
            break;
        }
        cans[activeCan].SetActive(false);
        activeCan++;
        cans[activeCan].SetActive(true);
    }
}
