using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examiner : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "emptyWall" && WallBreak.hitWall)
        {
            WallBreak.hitWall = false;
            StartCoroutine(SetSpeedTrue());
        }
    }
    
    IEnumerator SetSpeedTrue()
    {
        yield return new WaitForSeconds(1);
        WallBreak.hitWall = true;
        StartCoroutine(SetSpeedFalse());
    }
    
    IEnumerator SetSpeedFalse()
    {
        yield return new WaitForSeconds(1);
        WallBreak.hitWall = false;
    }
}
