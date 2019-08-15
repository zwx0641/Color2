using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestUI : MonoBehaviour
{
    public GameObject scores;
    
    public void SetCanvas()
    {
        GameObject.Find("YourScore").SetActive(false);
        scores.SetActive(true);
        scores.transform.DOScale(new Vector3(1, 1, 0), 1);
    }
}
