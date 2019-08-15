using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruveData : MonoBehaviour
{
    /// <summary>
    /// 动画曲线
    /// </summary>
    public AnimationCurve animationCurve;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float CruveValue = animationCurve.Evaluate(Time.time);
        GameObject.Find("Cube").transform.localScale = new Vector3(CruveValue, CruveValue, CruveValue);
    }
}
