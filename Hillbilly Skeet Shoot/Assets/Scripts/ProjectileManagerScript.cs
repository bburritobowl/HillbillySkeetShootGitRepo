using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ProjectileManagerScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip gotShotSFX;
    public GameObject particlePrefab;
    public int scoreIncrease;
    public GameManagerScript gameManagerScript;

    public void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }
    public void HitByRay()
    {
        Debug.Log("Projectile Hit");
        gameManagerScript.score += scoreIncrease;
        // GameObject tempBoomEffect;
        // tempBoomEffect = Instantiate(particlePrefab,gameObject.transform.position, Quaternion.identity) as GameObject;
        // Destroy(tempBoomEffect, 3.0f);
        audioSource.PlayOneShot(gotShotSFX);
        Destroy(gameObject);
    }
}
