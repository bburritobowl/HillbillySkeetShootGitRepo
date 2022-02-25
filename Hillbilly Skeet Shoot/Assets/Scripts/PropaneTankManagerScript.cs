using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PropaneTankManagerScript : MonoBehaviour
{
    public GameManagerScript gameManagerScript;
    [SerializeField] int hit = 0;
    public GameObject explosionParticles;
    public AudioClip explosionAudioClip;
    public AudioSource audioSource;
    public float volume = 3.0f;

    public void HitByRay()
    {
        hit++;
        switch(hit)
        {
            case 1:
            GameManagerScript.score += 5;
            break;
            case 2:
            GameManagerScript.score += 10;
            break;
            case 3:
            GameManagerScript.score += 15;
            break;
            case 4:
            Explode();
            break;
        }
    }

    private void Explode()
    {
        gameManagerScript.LoseALife();
        GameObject tempExplosionEffect;
        tempExplosionEffect = Instantiate(explosionParticles, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        Destroy(tempExplosionEffect, 2.0f);
        audioSource.PlayOneShot(explosionAudioClip, volume);
        Destroy(gameObject);
    }
}
