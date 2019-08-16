using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Examiner : MonoBehaviour
{

    public static float Makeup = 0.8f;
        
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "emptyWall" && WallBreak.hitWall)
        {
            //WallBreak.hitWall = false;

            //StartCoroutine(SetSpeedFalse(Makeup));
/*          
            StartCoroutine(SetImageShow());
*/
            WallBreak.hitWall = false;
        }
    }
    
/*    IEnumerator SetSpeedTrue(float makeup)
    {
        yield return new WaitForSeconds(makeup);
        WallBreak.hitWall = true;
        StartCoroutine(SetSpeedFalse());
        StartCoroutine(SetImageShow());
    }*/
    
    IEnumerator SetSpeedFalse(float makeup)
    {
        yield return new WaitForSeconds(makeup);
        WallBreak.hitWall = false;
        GameObject.Find("Blood").GetComponent<Image>().fillAmount = 1;

    }

    IEnumerator SetImageShow()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("Blood").GetComponent<Image>().fillAmount = 1;
    }
    
}
