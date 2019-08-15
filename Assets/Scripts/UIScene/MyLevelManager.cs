using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyLevelManager : MonoBehaviour
{
    /// <summary>
    /// 切场景时，场景被破坏 静态变量才能被保存
    /// </summary>
    static string nextlevelName;
    /// <summary>
    /// 异步加载方法返回值
    /// </summary>
    private AsyncOperation async;

    /// <summary>
    /// 伪进度
    /// </summary>
    public float tempProgress;
    /// <summary>
    /// 表示进度的text
    /// </summary>
    public Text text;

    /// <summary>
    /// 表示进度的Slider
    /// </summary>
    public Slider slider;

    /// <summary>
    /// 音频播放管理
    /// </summary>
    //private SoundEffectsInBegin soundEffectsInBegin;
    
    // Start is called before the first frame update
    void Start()
    {
        tempProgress = 0;
        if (SceneManager.GetActiveScene().name == "Loading")
        {
            //异步加载场景
            async = SceneManager.LoadSceneAsync(nextlevelName);
            //不允许加载完毕后立即切场景
            async.allowSceneActivation = false;
        }
        //if(SceneManager.GetActiveScene().name == "UIScene")
        //    soundEffectsInBegin = GameObject.FindWithTag("GameController").GetComponent<SoundEffectsInBegin>();
    }

    public void LoadLoadingScene(string nextLevel)
    {
        //if (SceneManager.GetActiveScene().name == "UIScene")
        //    soundEffectsInBegin = GameObject.FindWithTag("GameController").GetComponent<SoundEffectsInBegin>();
        nextlevelName = nextLevel;
        SceneManager.LoadScene("Loading");
    }

    // Update is called once per frame
    void Update()
    {
        //如果已经到了Loading场景
        if (text && slider)
        {
            tempProgress = Mathf.Lerp(tempProgress, async.progress, Time.deltaTime);

            text.text = ((int)(tempProgress / 9 * 10 * 100)).ToString() + "%";
            slider.value = tempProgress / 9 * 10;

            if (tempProgress / 9 * 10 > 0.995f)
            {
                tempProgress = 1;
                text.text = ((int)(tempProgress * 100)).ToString() + "%";
                slider.value = tempProgress / 9 * 10;
                async.allowSceneActivation = true;
            }
        }
    }

}
