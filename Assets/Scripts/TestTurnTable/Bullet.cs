using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    /// <summary>
    /// 子弹数组
    /// </summary>
    public GameObject[] bullets;
    /// <summary>
    /// 玩家
    /// </summary>
    public GameObject player;
    /// <summary>
    /// 色轮旋转后停留的区域
    /// </summary>
    public Vector3 endRotate;
    /// <summary>
    /// 实例化出来的子弹
    /// </summary>
    private GameObject bulletObj;
    /// <summary>
    /// 子弹速度
    /// </summary>
    private float speed = 3.0f;
    /// <summary>
    /// 是否松开
    /// </summary>
    private bool hadRelease = false;

    private JudgeArea area;
    /// <summary>
    /// 子弹发射个数
    /// </summary>
    private int bulletTime;
    // Start is called before the first frame update
    void Start()
    {
        area = GameObject.Find("Canvas").transform.GetComponentInChildren<JudgeArea>();
        GameObject.Find("Canvas").transform.GetComponentInChildren<RepeatOn>().OnRelease.AddListener(ReleaseAndShoot);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (area.canMakeBullet && hadRelease) 
        {
            Debug.Log(endRotate.z + "endRotate");
            bulletTime++;
            if ((endRotate.z >= 0 && endRotate.z < 60) || (endRotate.z >= 300 && endRotate.z < 360))
            {
                bulletObj = Instantiate(bullets[0], player.transform.position, Quaternion.identity);
                bulletObj.transform.DOMove(player.transform.position + player.transform.forward * 200, 15.0f);
            }
            if ((endRotate.z >= 60 && endRotate.z < 180))
            {
                bulletObj = Instantiate(bullets[2], player.transform.position, Quaternion.identity);
                bulletObj.transform.DOMove(player.transform.position + player.transform.forward * 200, 15.0f);
            }
            if (endRotate.z < 300 && endRotate.z >= 180)
            {
                bulletObj = Instantiate(bullets[1], player.transform.position, Quaternion.identity);
                bulletObj.transform.DOMove(player.transform.position + player.transform.forward * 200, 15.0f);
            }
            area.canMakeBullet = false;
            hadRelease = false;
        }
    }

    private void ReleaseAndShoot()
    {
        hadRelease = true;
    }
}
