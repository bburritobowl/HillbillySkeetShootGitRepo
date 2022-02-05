using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastFiringScript : MonoBehaviour
{
    public float hitForce = 2000.0f;
    //Particle and sound variables
    //public ParticleSystem muzzleBlast;
    public AudioSource audioSource;
    public AudioClip[] gunshot;
    [SerializeField] float volume = 4.0f;
    // public GameObject bulletHoleParticles;
    // public GameObject boomBoomParticles;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireTheGun();
        }   
    }

    void FireTheGun()
    {
        //Play gunshot noise
        //audioSource.PlayOneShot(gunshot[0], volume);

        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

         // Does the ray intersect any objects in the Default layer?
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Did Hit - " + hit.transform.name);

            if (hit.rigidbody != null)
            {
                // blast it away!
                hit.rigidbody.AddForce (-hit.normal * hitForce);
                // this particle system is the BIG BOOM for when we hit cars or other objects that we send flying
                // GameObject tempBoomEffect;
                // tempBoomEffect = Instantiate(boomBoomParticles, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal)) as GameObject;
                // Destroy(tempBoomEffect, 3.0f);
            } 
            else
            {
                // this particle system is just the bullet holes on walls and other 
                // objects we can't BLAST away (they have no rigidbody)
                // GameObject tempBulletEffect;
                // tempBulletEffect = Instantiate(bulletHoleParticles, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal)) as GameObject;
                // Destroy(tempBulletEffect, 10.0f);
                // audioSource.PlayOneShot(gunshot[1], volume);
            }
        }
        else
        {
            // Debug.DrawRay(muzzleTransform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.blue, 3.0f);
            Debug.Log("Did not Hit");
        }
           }
}
