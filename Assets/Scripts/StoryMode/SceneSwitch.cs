using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    private SoundEffectsInGame soundEffectsInGame;
    // Start is called before the first frame update
    void Start()
    {
        soundEffectsInGame = GameObject.Find("LevelSeletor").GetComponent<SoundEffectsInGame>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchScene()
    {
        AudioSource.PlayClipAtPoint(soundEffectsInGame.soundEffects[5], transform.position);
        StartCoroutine(switchTheScene());
    }

    public void loadThisGameAgain()
    {
        AudioSource.PlayClipAtPoint(soundEffectsInGame.soundEffects[5], transform.position);
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
