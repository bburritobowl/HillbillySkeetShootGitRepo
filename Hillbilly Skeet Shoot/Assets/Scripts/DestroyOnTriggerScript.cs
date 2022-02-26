using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTriggerScript : MonoBehaviour
{
    public GameManagerScript gameManagerScript;
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        gameManagerScript.LoseALife();
    }
}
