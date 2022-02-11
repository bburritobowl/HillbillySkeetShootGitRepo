using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanScript : MonoBehaviour
{
    public CanManagerScript canManagerScript;
    void Start()
    {
        canManagerScript = this.gameObject.transform.parent.GetComponent<CanManagerScript>();
    }
    public void HitByRay()
    {
        canManagerScript.WasHit();
    }
}
