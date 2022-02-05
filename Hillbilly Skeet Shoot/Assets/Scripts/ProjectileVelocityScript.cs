using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileVelocityScript : MonoBehaviour
{
    public float startSpeed = 25f;
    public float selfDestructTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        int adjustStartSpeed = Random.Range(-5, 5);
        startSpeed += adjustStartSpeed;
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = transform.forward * startSpeed;
    }
}
