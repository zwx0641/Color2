using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// BGM数组
    /// </summary>
    public AudioClip[] clip;
    /// <summary>
    /// 当前播放的是谁
    /// </summary>
    private int playIndex;
    /// <summary>
    /// 当前是否允许播放
    /// </summary>
    private bool canPlay;
    /// <summary>
    /// audioSource组件
    /// </summary>
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        canPlay = true;
        playIndex = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlay)
        {
            PlayAudio();
            canPlay = false;
        }

        if (!audioSource.isPlaying)
        {
            playIndex++;
            if (playIndex >= clip.Length)
            {
                playIndex = 0;
            }

            canPlay = true;
        }
    }

    void PlayAudio()
    {
        audioSource.clip = clip[playIndex];
        audioSource.Play();
    }
}
