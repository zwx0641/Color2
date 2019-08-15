using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchStory : MonoBehaviour
{
    /// <summary>
    /// 获取玩家所选择的关卡
    /// </summary>
    private GetInput getInput;
    /// <summary>
    /// 关卡的父物体
    /// </summary>
    private GameObject levelParent;

    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    // Start is called before the first frame update
    void Start()
    {
        levelParent = GameObject.Find("LevelParent");
        getInput = levelParent.GetComponent<GetInput>();
        //level1 = levelParent.transform.GetChild(0).gameObject;
        //level2 = levelParent.transform.GetChild(1).gameObject;
        //level3 = levelParent.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        SwtichToStory();
        Debug.Log("CurrentPaper" + GetInput.currentPaper);
        Debug.Log("name" + GetInput.name);
    }

    private void SwtichToStory() 
    {
        if (GetInput.currentPaper == "1")
        {
            level1.SetActive(true);
            level2.SetActive(false);
            level3.SetActive(false);
        }
        if (GetInput.currentPaper == "2")
        {
            Debug.Log("22");
            level1.SetActive(false);
            level2.SetActive(true);
            level3.SetActive(false);
        }
        if (GetInput.currentPaper == "3")
        {
            level1.SetActive(false);
            level2.SetActive(false);
            level3.SetActive(true);
        }

    }
}
