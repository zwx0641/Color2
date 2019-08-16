using System.Collections;
using System.Collections.Generic;
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
    
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "UIScene")
        {
            bookPro = GameObject.Find("Canvas/ChooseLevelPanel/BookPro").GetComponent<BookPro>();
            soundEffectsInBegin = GameObject.FindWithTag("GameController").GetComponent<SoundEffectsInBegin>();
            AudioSource = GameObject.FindWithTag("GameController").GetComponent<AudioSource>();
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "UIScene")
            currentPaper = bookPro.currentPaper.ToString();
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
}
