using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsInGame : MonoBehaviour
{
    public AudioClip[] soundEffects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenTheScoreScreen()
    {
        AudioSource.PlayClipAtPoint(soundEffects[0], transform.position);
    }
}
