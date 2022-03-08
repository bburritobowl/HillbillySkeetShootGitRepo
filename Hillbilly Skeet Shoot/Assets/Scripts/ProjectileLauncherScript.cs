using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncherScript : MonoBehaviour
{
    public float launchTimer = 5f;
    public List<GameObject> projectiles;
    public GameObject[] secondaryObjects;
    public GameObject[] explodingObjects;

    private int timerTracker = 0; //bcos I'm angry
    [SerializeField] float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchProjectiles", launchTimer, launchTimer);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    void FixedUpdate()
    {
        if(timer >= 10f && timerTracker == 0)
        {
            Debug.Log("adding to array should happen now");
            projectiles.Add(secondaryObjects[0]);
            timerTracker++;
        }
        else if(timer >= 20f && timerTracker == 1)
        {
            Debug.Log("Okay this is the one with the float first and timer second");
            projectiles.Add(secondaryObjects[1]);
            timerTracker++;
        }
        else if(timer >= 30f && timerTracker == 2)
        {
            projectiles.Add(explodingObjects[0]);
            timerTracker++;
        }
    }

    void LaunchProjectiles()
    {
        int randomObject = Random.Range(0, projectiles.Count);
        Instantiate(projectiles[randomObject], transform.position, transform.rotation);
    }
}
