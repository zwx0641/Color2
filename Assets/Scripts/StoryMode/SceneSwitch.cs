using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    private SoundEffectsInGame soundEffectsInGame;
    private AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        soundEffectsInGame = GameObject.Find("LevelSeletor").GetComponent<SoundEffectsInGame>();
        AudioSource = GameObject.Find("LevelSeletor").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchScene()
    {
        this.AudioSource.PlayOneShot(soundEffectsInGame.soundEffects[5], 1.0f);
        
        StartCoroutine(switchTheScene());
    }

    public void loadThisGameAgain()
    {
        this.AudioSource.PlayOneShot(soundEffectsInGame.soundEffects[5], 1.0f);
        UIManager.bulletTime = 50;
        StartCoroutine(loadAgain());
    }

    IEnumerator loadAgain()
    {
        yield return new WaitForSeconds(0.5f);
        
        SceneManager.LoadScene("StoryMode");
    }
    
    IEnumerator switchTheScene()
    {
        yield return new WaitForSeconds(0.5f);
        
        SceneManager.LoadScene("UIScene");
        
    }
        
}
