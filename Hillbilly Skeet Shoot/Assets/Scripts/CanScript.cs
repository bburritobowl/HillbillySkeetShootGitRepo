using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanScript : MonoBehaviour
{
    public CanSwitchScript canSwitchScript;
    void Start()
    {
        canSwitchScript = this.gameObject.transform.parent.GetComponent<CanSwitchScript>();
    }
    public void HitByRay()
    {
        canSwitchScript.WasHit();
    }
}
