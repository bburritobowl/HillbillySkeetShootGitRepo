using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanScript : MonoBehaviour
{
    public CanManagerScript canManagerScript;
    
    public void HitByRay()
    {
        canManagerScript.WasHit();
    }
}