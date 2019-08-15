using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NewsMake : MonoBehaviour
{
    public Vector2 NewNewsPos;

    public bool canMakeNews;

    public GameObject NewNews;
    private GameObject NewNewsObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMakeNews)
        {
            NewNewsObj = Instantiate(NewNews, NewNewsPos + new Vector2(0, 10), Quaternion.identity);
            NewNewsObj.transform.SetParent(this.transform);
            NewNewsObj.transform.DOMove(NewNewsPos, 1.0f);
            NewNewsObj.transform.DOScale(new Vector3(0.2f, 0.2f, 1.0f), 0.2f);
            canMakeNews = false;
        }
    }
}
