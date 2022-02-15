using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ChickenManagerScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip chickenSqueak;

    public void HitByRay()
    {
        GameManagerScript.score += 3;
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        audioSource.PlayOneShot(chickenSqueak);
    }
}
