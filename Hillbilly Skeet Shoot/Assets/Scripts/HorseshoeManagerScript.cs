using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class HorseshoeManagerScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip metalShot;
    public void HitByRay()
    {
        GameManagerScript.score += 5;
        Destroy(gameObject);
        audioSource.PlayOneShot(metalShot);
    }
}
