using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSphereScript : MonoBehaviour
{
    public float sphereRadius = 5f;
    public float constantZPos = 0f;
    public float hitForce = 1000.0f;
    public AudioSource audioSource;
    public AudioClip gunshot;
    [SerializeField] float volume = 4.0f;
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
        audioSource.PlayOneShot(gunshot, volume);

        //get the information from the mouse click
        Vector3 checkSphereCenter;
        checkSphereCenter.x = Input.mousePosition.x;
        checkSphereCenter.y = Input.mousePosition.y; //Set the x and y positions to the mouse click ones
        checkSphereCenter.z = constantZPos; //hardcode the z
        
        //use checksphere and put all your damagey things in it
        if(CheckSphere(checkSphereCenter, sphereRadius))
        {
            Collider[] objectsHit = Physics.OverlapSphere(checkSphereCenter, sphereRadius);
            foreach(Collider hits in objectsHit)
                if(hits.gameObject.CompareTag("HittableObject"))
                {
                    other.rigidbody.AddForce (-hit.normal * hitForce);
                    other.transform.SendMessage ("HitByRay");
                }
        }
    }
}
