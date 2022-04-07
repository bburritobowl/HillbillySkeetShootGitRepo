using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSphereScript : MonoBehaviour
{
    public float sphereRadius = 5f;
    private Vector3 checkSphereCenter;
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
        // Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        //Debug.Log(Input.mousePosition + "Where the mouse");
        // Vector3 temp = Input.mousePosition;
        // Vector3 checkSphereCenter = new Vector3();
        
        checkSphereCenter.x = Input.mousePosition.x;//Set the x and y positions to the mouse click ones
        checkSphereCenter.y = Input.mousePosition.y;
        checkSphereCenter.z = constantZPos; //hardcode the z
        Debug.Log(checkSphereCenter + "Where the sphere");
        
        //use checksphere and put all your damagey things in it
        if(Physics.CheckSphere(checkSphereCenter, sphereRadius))
        {
            Collider[] objectsHit = Physics.OverlapSphere(checkSphereCenter, sphereRadius);
            foreach(Collider hits in objectsHit)
                if(hits.gameObject.CompareTag("Projectile"))
                {
                    //hits.GetComponent<Rigidbody>().AddForce (-hit.normal * hitForce);
                    hits.transform.SendMessage ("HitByRay");
                }
        }
    }
}
