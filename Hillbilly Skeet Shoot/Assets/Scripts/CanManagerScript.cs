using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanManagerScript : MonoBehaviour
{
    public GameObject[] cans;
    [SerializeField] int activeCan = 0;
    public GameManagerScript gameManagerScript;
    // Start is called before the first frame update
    public void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }
    public void WasHit()
    {
        Debug.Log("Message Received");
        switch(activeCan)
        {
            case 0:
            gameManagerScript.score += 1;
            break;

            case 1:
            gameManagerScript.score += 2;
            break;

            case 2:
            gameManagerScript.score += 3;
            break;

            case 3:
            gameManagerScript.score += 4;
            break;

            case 4:
            gameManagerScript.score += 5;
            Destroy(gameObject);
            break;
        }
        cans[activeCan].SetActive(false);
        activeCan++;
        cans[activeCan].SetActive(true);
    }
}
