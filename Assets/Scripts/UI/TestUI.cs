using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TestUI : MonoBehaviour
{
    public GameObject scores;
    private SoundEffectsInGame soundEffectsInGame;
    private AudioSource AudioSource;

    private Image image;
    void Start()
    {
        soundEffectsInGame = GameObject.Find("LevelSeletor").GetComponent<SoundEffectsInGame>();
        //bloodImage.fillAmount = 1;
        AudioSource = GameObject.Find("LevelSeletor").GetComponent<AudioSource>();
        image = this.GetComponent<Image>();
    }

    public void SetCanvas()
    {
        this.AudioSource.PlayOneShot(soundEffectsInGame.soundEffects[5], 1.0f);
        GameObject.Find("YourScore").SetActive(false);
        scores.SetActive(true);
        scores.transform.DOScale(new Vector3(1, 1, 0), 1);
        //image.DOColor(new Color(0, 0, 100, 255), 1.0f);
    }
}
