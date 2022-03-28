using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanManagerScript : MonoBehaviour
{
    public GameObject[] cans;
    [SerializeField] int activeCan = 0;
    public GameManagerScript gameManagerScript;
    public AudioSource audioSource;
    public AudioClip gotShotSFX;
    public GameObject particlePrefab;
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
            audioSource.PlayOneShot(gotShotSFX);
            break;

            case 1:
            gameManagerScript.score += 2;
            audioSource.PlayOneShot(gotShotSFX);
            break;

            case 2:
            gameManagerScript.score += 3;
            audioSource.PlayOneShot(gotShotSFX);
            break;

            case 3:
            gameManagerScript.score += 4;
            audioSource.PlayOneShot(gotShotSFX);
            break;

            case 4:
            gameManagerScript.score += 5;
            GameObject tempBoomEffect;
            tempBoomEffect = Instantiate(particlePrefab,gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(tempBoomEffect, 3.0f);
            audioSource.PlayOneShot(gotShotSFX);
            Destroy(gameObject);
            break;
        }
        cans[activeCan].SetActive(false);
        activeCan++;
        cans[activeCan].SetActive(true);
    }
}
