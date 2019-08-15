using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCurveBloodAndAttack : MonoBehaviour
{
    public AnimationCurve curve;
    private float CruveValue1;
    // Start is called before the first frame update
    void Start()
    {
        //float CruveValue = curve.Evaluate(0.071428f);
        float CruveValue1 = curve.Evaluate(Time.time);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("CruveValue" + CruveValue);
        float CruveValue1 = curve.Evaluate(Time.time);
        Debug.Log("CruveValue1 " + CruveValue1 + " Time.time " + Time.time);
    }
}
