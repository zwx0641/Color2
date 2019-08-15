using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;//为了使用dotween插件

public class APPOpen : MonoBehaviour
{
    private GameObject APPToOpen;
    private List<GameObject> APPToClose;
    // Start is called before the first frame update
    void Start()
    {
        APPToClose = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenApp(GameObject appToOpen)
    {
        //Debug.Log(appToOpen);
        this.APPToOpen = appToOpen;
        APPToClose.Add(APPToOpen);
        APPToOpen.transform.DOScaleX(22.5f, 0.05f);
        APPToOpen.transform.DOScaleY(45.0f, 0.05f);
    }
    public void CloseApp()
    {
        if (APPToClose.Count > 0)
        {
            APPToClose[APPToClose.Count - 1].transform.DOScaleX(0.01f, 0.1f);
            APPToClose[APPToClose.Count - 1].transform.DOScaleY(0.01f, 0.1f);
            APPToClose.Remove(APPToClose[APPToClose.Count - 1]);
        }
    }
}
