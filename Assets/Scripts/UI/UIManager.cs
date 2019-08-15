using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// 子弹发射个数文本
    /// </summary>
    private Text bulletTimetext;
    /// <summary>
    /// 子弹发射个数
    /// </summary>
    public static int bulletTime = 50;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletTimetext = GameObject.Find("Canvas/BulletTimeText").transform.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletTime >= 0)
        {
            bulletTimetext.text = "剩余: "+ bulletTime + "个球";
        }
    }
}
