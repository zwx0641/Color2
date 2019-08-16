using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetInput : MonoBehaviour
{
    //输入框
    public InputField inputName;
    public static string name;
    public static string currentPaper;
    /// <summary>
    /// 翻书脚本
    /// </summary>
    private BookPro bookPro;

    private SoundEffectsInBegin soundEffectsInBegin;
    private AudioSource AudioSource;
    private Text alert;

    private Text text1;

    private Text text2;
    // Start is called before the first frame update
    void Start()
    {
        
        if(SceneManager.GetActiveScene().name == "UIScene")
        {
            bookPro = GameObject.Find("Canvas/ChooseLevelPanel/BookPro").GetComponent<BookPro>();
            soundEffectsInBegin = GameObject.FindWithTag("GameController").GetComponent<SoundEffectsInBegin>();
            AudioSource = GameObject.FindWithTag("GameController").GetComponent<AudioSource>();
            text1 = GameObject.Find("HintText2").GetComponent<Text>();
            text2 = GameObject.Find("HintText3").GetComponent<Text>();

        }

        if (SceneManager.GetActiveScene().name == "StoryMode")
        {
            alert = GameObject.Find("Alert").GetComponent<Text>();

            alert.DOFade(1, 0.1f);
            StartCoroutine(AlertShow());
        }

    }

    IEnumerator AlertShow()
    {
        yield return new WaitForSeconds(1.0f);
        alert.DOFade(0, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "UIScene")
        {
            currentPaper = bookPro.currentPaper.ToString();
            if (currentPaper == "2")
            {
                text1.DOFade(1, 0.5f);
                text2.DOFade(0, 0.5f);
            }

            if (currentPaper == "3")
            {
                text1.DOFade(0, 0.5f);
                text2.DOFade(1, 0.5f);
            }

        }
    }

    public void GetInputName()
    {
        name = inputName.text;
        currentPaper = bookPro.currentPaper.ToString();
    }

    public void GetLevelNumber(int num)
    {
        this.AudioSource.PlayOneShot(soundEffectsInBegin.soundEffects[0],1.0f);
        currentPaper = num.ToString();
    }

    public void ActiveProject()
    {
        if (currentPaper == "2")
        {
            text1.DOFade(1, 0.5f);
            text2.DOFade(0, 0.5f);
        }

        if (currentPaper == "3")
        {
            text1.DOFade(0, 0.5f);
            text2.DOFade(1, 0.5f);
        }
    }
}
