using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestUI : MonoBehaviour
{
    public GameObject scores;
    private SoundEffectsInGame soundEffectsInGame;

    void Start()
    {
        soundEffectsInGame = GameObject.Find("LevelSeletor").GetComponent<SoundEffectsInGame>();
        //bloodImage.fillAmount = 1;
    }

    public void SetCanvas()
    {
        AudioSource.PlayClipAtPoint(soundEffectsInGame.soundEffects[5], transform.position);
        GameObject.Find("YourScore").SetActive(false);
        scores.SetActive(true);
        scores.transform.DOScale(new Vector3(1, 1, 0), 1);
    }
}
