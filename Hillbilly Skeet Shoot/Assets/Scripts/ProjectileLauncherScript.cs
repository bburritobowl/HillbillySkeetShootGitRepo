using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncherScript : MonoBehaviour
{
    public float launchTimer = 5f;
    public List<GameObject> projectiles;
    public GameObject[] secondaryObjects;
    public GameObject[] explodingObjects;
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
        if(Mathf.Approximately(timer, 5f))
        {
            projectiles.Add(secondaryObjects[0]);
        }
        else if(Mathf.Approximately(timer, 10f))
        {
            projectiles.Add(secondaryObjects[1]);
        }
        else if(Mathf.Approximately(timer, 15f))
        {
            projectiles.Add(explodingObjects[0]);
        }
    }

    void LaunchProjectiles()
    {
        int randomObject = Random.Range(0, projectiles.Count);
        Instantiate(projectiles[randomObject], transform.position, transform.rotation);
    }
}
