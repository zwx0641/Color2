using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GetNameAndClose : MonoBehaviour
{
    private GameObject GetNamePanel;
    private Image GetNamePanelColor;

    private GameObject openAnim;
    private SpriteRenderer openRender;

    private Camera camera;

    public SoundEffectsInBegin soundEffectsInBegin;
    private AudioSource AudioSource;
    private GameObject hintText;

    // Start is called before the first frame update
    void Start()
    {
        GetNamePanel = GameObject.Find("Canvas/GetNamePanel");
        GetNamePanelColor = GetNamePanel.GetComponent<Image>();
        openAnim = GameObject.Find("OpenAnim");
        openRender = openAnim.GetComponent<SpriteRenderer>();
        camera = GameObject.Find("UICameraForBook").GetComponent<Camera>();
        soundEffectsInBegin = GameObject.FindWithTag("GameController").GetComponent<SoundEffectsInBegin>();         
        AudioSource = GameObject.FindWithTag("GameController").GetComponent<AudioSource>();
        hintText = GameObject.Find("HintText");
    }

    // Update is called once per frame
    void Update()
    {
        if (openAnim.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95f)
        {
            openAnim.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f);
            openRender.DOFade(0, 0.5f);
            camera.depth = 1;    
        }
        
    }

    public void InvisableThisPanel()
    {
        this.AudioSource.PlayOneShot(soundEffectsInBegin.soundEffects[0], 1.0f);
        //GetNamePanel.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f);
        GetNamePanelColor.enabled = false;
        hintText.GetComponent<Text>().DOFade(1, 0.5f);
        Destroy(hintText,5.0f);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
