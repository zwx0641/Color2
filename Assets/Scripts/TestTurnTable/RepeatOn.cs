using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;

public class RepeatOn : MonoBehaviour,IPointerUpHandler
{
    #region public
    /*(长按事件)是否只调用一次*/
    public bool IsInvokeOnce = false;
    #endregion

    #region private
    /*()是否被调用*/
    private bool HadInvoke = false;
    /*点击时间超过这个时间时被视为长按*/
    private float interval = 0.1f;
    /*按下那一刻的时间*/
    private float ClickTime;
    /*是否按下*/
    private bool IsClick = false;
    #endregion

    #region event
    public UnityEvent OnPress = new UnityEvent();//按住时调用
    public UnityEvent OnRelease = new UnityEvent();//松开时调用
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsInvokeOnce && HadInvoke) return;
        if (IsClick)
        {
            //说明按住的时间大于interval
            if ((Time.time - ClickTime) > interval)
            {
                OnPress.Invoke();
                HadInvoke = true;
            }
        }
    }


    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    //transform.GetComponent<JudgeArea>().beginRotate = transform.rotation.eulerAngles;
    //    IsClick = true;
    //    ClickTime = Time.time;//将点击此刻的时间赋给ClickTime
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    IsClick = false;
    //    HadInvoke = false;
    //    OnRelease.Invoke();
    //}

    public void OnPointerUp(PointerEventData eventData)
    {
        IsClick = false;
        HadInvoke = false;
        OnRelease.Invoke();
    }
}
