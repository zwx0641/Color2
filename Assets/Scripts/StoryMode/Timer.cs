using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private int hour;
    private int minute;
    private int second;
    private int millisecond;
    /// <summary>
    /// 当前过去时间UI
    /// </summary>
    public Text text_timeSpend;
    /// <summary>
    /// 通关时间
    /// </summary>
    public Text text_success;
    /// <summary>
    /// 是否通关 0为为通关 1为刚刚通关 2为通关后
    /// </summary>
    public int HadSuccess;
    /// <summary>
    /// 当前过去时间
    /// </summary>
    private float TimeSpend;

    private int ScoreGet;
    /// <summary>
    /// 获取玩家名字
    /// </summary>
    private GetInput getInput;

    // Start is called before the first frame update
    void Start()
    {
        HadSuccess = 0;
        getInput = GameObject.FindWithTag("GameController").GetComponent<GetInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HadSuccess == 0) 
        {
            ScoreGet = WallBreak.yourScore;
        }
        if (HadSuccess == 1) 
        {
            transform.GetComponent<ScoreManager>().UpdateJson(GetInput.name, ScoreGet);
            HadSuccess = 2;
        }
    }
}
