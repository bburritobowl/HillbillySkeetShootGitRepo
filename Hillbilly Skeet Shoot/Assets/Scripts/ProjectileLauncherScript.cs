using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncherScript : MonoBehaviour
{
    public float launchTimer = 5f;
    public GameObject[] projectiles;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchProjectiles", launchTimer, launchTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LaunchProjectiles()
    {
        int randomObject = Random.Range(0, projectiles.Length);
        Instantiate(projectiles[randomObject], transform.position, transform.rotation);
    }
}
