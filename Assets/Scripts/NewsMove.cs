using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class NewsMove : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    #region private
    //新闻框初始的位置
    private Vector2 originPos;
    //拖拽完毕后 新闻框的位置
    private Vector2 endPos;
    //偏移位置
    private Vector2 offsetPos;
    //新闻被废弃 飞去的位置
    private Vector2 giveUpPos;
    //新闻被选择 飞去的位置
    private Vector2 getPos;
    //新闻被废弃 飞去的位置
    private GameObject giveUpObj;
    //新闻被选择 飞去的位置
    private GameObject getObj;
    //父物体 管理新新闻的生成
    private NewsMake newsMaker;
    #endregion

    #region public
    #endregion

    public void OnBeginDrag(PointerEventData eventData)
    {
        originPos = eventData.position;
        newsMaker.NewNewsPos = transform.position;
        //Debug.Log(originPos + "originPos");
        //this.transform.position = eventData.position;
    }
        
    public void OnDrag(PointerEventData eventData)
    {

    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.position.x > originPos.x)
        {
            transform.DOPunchPosition(new Vector3(1, 0, 0), 0.4f, 4, 0.5f);
            transform.DOPunchRotation(new Vector3(0, 0, -30), 0.4f, 4, 0.5f);
        }
        else if (eventData.position.x < originPos.x)
        {
            transform.DOPunchPosition(new Vector3(-1, 0, 0), 0.4f, 4, 0.5f);
            transform.DOPunchRotation(new Vector3(0, 0, 30), 0.4f, 4, 0.5f);
        }
        
        endPos = eventData.position;
        //Debug.Log(endPos + "endPos");
        offsetPos = endPos - originPos;
        //Debug.Log(offsetPos + "offsetPos");
        //判断新闻框是被选择 还是被废弃
        if (Vector2.Distance(originPos,endPos) > 1000 && eventData.position.x > originPos.x)
        {
            //选择
            transform.DOMove(getPos, 1.0f);
            transform.DOScale(new Vector3(0.01f, 0.01f, 0.01f), 1.0f);
            newsMaker.canMakeNews = true;        //新闻框被处理后 可以生成新的新闻框来填补
        }
        if (Vector2.Distance(originPos,endPos) > 1000 && eventData.position.x < originPos.x)
        {
            //抛弃
            transform.DOMove(giveUpPos, 1.0f);
            transform.DOScale(new Vector3(0.01f, 0.01f, 0.01f), 1.0f);
            newsMaker.canMakeNews = true;        //新闻框被处理后 可以生成新的新闻框来填补
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        giveUpObj = GameObject.Find("giveup");
        getObj = GameObject.Find("get");
        giveUpPos = giveUpObj.transform.position;
        getPos = getObj.transform.position;
        newsMaker = GameObject.Find("Canvas/ShellPanel/OpenNewsPanel/UpPanel").GetComponent<NewsMake>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void move
}
