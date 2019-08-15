using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TurnTableMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<RepeatOn>().OnPress.AddListener(MoveTurnTable);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveTurnTable()
    {
        transform.DOBlendableRotateBy(Vector3.forward * Time.deltaTime * 200.0f, 0.05f);
        //transform.DOBlendableRotateBy(Vector3.forward * 3.0f, 0.3f);
    }
}
