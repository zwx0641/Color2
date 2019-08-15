using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeArea : MonoBehaviour
{
    /// <summary>
    /// 计算旋转角度的参照物体/
    /// </summary>
    private GameObject datumObj;
    /// <summary>
    /// 指针物体
    /// </summary>
    public GameObject pointerObj;

    /// <summary>
    /// 开始转时的rotation.z
    /// </summary>
    public Vector3 beginRotate;
    /// <summary>
    /// 结束转时的rotation.z
    /// </summary>
    public Vector3 endRotate;
    /// <summary>
    /// 上一帧的rotation.z
    /// </summary>
    private Vector3 lastFrameRotate;
    /// <summary>
    /// 是否可以生成子弹
    /// </summary>
    public bool canMakeBullet = false;
    public GameObject GameController;
    private Bullet bulletScript;

    // Start is called before the first frame update
    void Start()
    {
        datumObj = this.transform.GetChild(0).gameObject;
        bulletScript = GameController.GetComponent<Bullet>();
        transform.GetComponent<RepeatOn>().OnRelease.AddListener(Release);
        //Debug.Log(beginRotate + "beginRotate");
    }

    private void Release()
    {
        endRotate = transform.rotation.eulerAngles;
        bulletScript.endRotate = this.endRotate;
        canMakeBullet = true;
        Debug.Log(endRotate.z + "endRotate1");
    }
}
