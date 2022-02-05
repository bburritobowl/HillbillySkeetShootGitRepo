using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncherScript : MonoBehaviour
{
    public float launchTimer = 5f;
    public GameObject cannonBall;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchCannonBalls", launchTimer, launchTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LaunchCannonBalls()
    {
        Instantiate(cannonBall, transform.position, transform.rotation);
    }
}
