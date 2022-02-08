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
        cans[activeCan].SetActive(false);
        activeCan++;
        cans[activeCan].SetActive(true);
    }
}
