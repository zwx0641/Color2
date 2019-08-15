using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;  

public class CloudMove : MonoBehaviour,IMove
{
    float speedTime = 5f;
    Vector3 pos;
    private Vector3 pos2;

    public void Move(Vector3 pos, Vector3 pos2, float SpeedTime)
    {
        Sequence sq = DOTween.Sequence();
        for (int i = 0; i < 12; i++)
        {
            sq.Append(transform.DOLocalMove(pos, speedTime));
            sq.Append(transform.DOLocalMove(pos2, speedTime));
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(transform.localPosition.x + 0.004f, transform.localPosition.y, transform.localPosition.z);
        pos2 = new Vector3(transform.localPosition.x - 0.004f, transform.localPosition.y, transform.localPosition.z);
        Move(pos, pos2, speedTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
