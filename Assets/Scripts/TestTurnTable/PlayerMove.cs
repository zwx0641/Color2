using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;
    private Timer timer;
    private GameObject camera;
    
    private GetInput getInput;
    [SerializeField]
    private float distance;

    private GameObject levelParent;

    public GameObject yourScore;
    
    private SoundEffectsInGame SoundEffectsInGame;
    // Start is called before the first frame update
    void Start()
    {
        levelParent = GameObject.Find("LevelParent");
        getInput = levelParent.GetComponent<GetInput>();
        //transform.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        timer = GameObject.FindWithTag("GameController").GetComponent<Timer>();
        camera = transform.GetChild(0).gameObject;

        SoundEffectsInGame = GameObject.Find("LevelSeletor").GetComponent<SoundEffectsInGame>();
        distance = 0.025f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.HadSuccess != 1)
        {
            transform.GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
            if (WallBreak.hitWall)
            {
                transform.GetComponent<Rigidbody>().velocity = Vector3.forward * speed * 15;
            }
        }
    }
    void OnCollisionEnter(Collision col)
    {
        //camera.transform.DOShakePosition(2, Vector3.one, 10, 90);
        Handheld.Vibrate();
        if (col.gameObject.tag == "outline")
        {
            AudioSource.PlayClipAtPoint(SoundEffectsInGame.soundEffects[3], transform.position);
            if (gameObject.transform.parent.name == "StoryMode1")
            {
                timer.HadSuccess = 1;
                camera.transform.DOMove(new Vector3(0.2799f, -1.010172f, 7.6226f), 2.0f);
                camera.transform.DORotate(new Vector3(0, 0, 0), 2.0f);
                Camera.main.orthographic = true;
                Camera.main.orthographicSize = 4.2f;
                transform.GetComponent<Rigidbody>().velocity = Vector3.zero;

                StartCoroutine(CallScores());
            }

            if (gameObject.transform.parent.name == "StoryMode2")
            {
                timer.HadSuccess = 1; 
                camera.transform.DOMove(new Vector3(138.3961f, -954.5437f, 12.21743f), 2.0f); 
                camera.transform.DORotate(new Vector3(0, 0, 0), 2.0f);
                Camera.main.orthographic = true;
                Camera.main.orthographicSize = 3.47f;
                transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }

            if (gameObject.transform.parent.name == "StoryMode3")
            {
                timer.HadSuccess = 1;
                camera.transform.DOMove(new Vector3(138.4361f, -954.6637f, 15.5594f), 2.0f);
                camera.transform.DORotate(new Vector3(0, 0, 0), 2.0f);
                Camera.main.orthographic = true;
                Camera.main.orthographicSize = 3.5f;
                transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }

    IEnumerator CallScores()
    {
        yield return new WaitForSeconds(2);
        yourScore.SetActive(true);
        yourScore.transform.DOScale(new Vector3(1, 1, 0), 1f);
    }
}
