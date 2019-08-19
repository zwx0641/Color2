using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

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
    private AudioSource AudioSource;

    public ParticleSystem particleB;
    public ParticleSystem particleY;

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
        AudioSource = GameObject.Find("LevelSeletor").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.HadSuccess != 1)
        {
            transform.GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
            var shape3 = particleB.shape;
            shape3.radius = 31.65f;
            var shape4 = particleY.shape;
            shape4.radius = 31.65f;

            if (WallBreak.hitWall)
            {
                transform.GetComponent<Rigidbody>().velocity = Vector3.forward * speed * 15;
                var shape = particleB.shape;
                shape.radius = 3.65f;
                var shape2 = particleY.shape;
                shape2.radius = 3.65f;    
            }

            if (WallBreak.falseShoot)
            {
                transform.GetComponent<Rigidbody>().velocity = Vector3.forward * speed * 10;
                var shape5 = particleB.shape;
                shape3.radius = 10.0f;
                var shape6 = particleY.shape;
                shape4.radius = 10.0f;
            }
        }
        yourScore.GetComponentInChildren<Text>().text = "本次得分:\n" + WallBreak.yourScore;
    }
    void OnCollisionEnter(Collision col)
    {
        //camera.transform.DOShakePosition(2, Vector3.one, 10, 90);
        Handheld.Vibrate();
        if (col.gameObject.tag == "outline")
        {
            this.AudioSource.PlayOneShot(SoundEffectsInGame.soundEffects[6], 0.1f);
            if (gameObject.transform.parent.name == "StoryMode1")
            {
                timer.HadSuccess = 1;
                camera.transform.DOMove(new Vector3(0.2799f, -1.010172f, 7.6226f), 2.0f);
                camera.transform.DORotate(new Vector3(0, 0, 0), 2.0f);
                Camera.main.orthographic = true;
                Camera.main.orthographicSize = 4.2f;
                transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
                
                
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

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "outline")
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(CallScores());
            }
        }
            
    }

    IEnumerator CallScores()
    {
        yield return new WaitForSeconds(1);
        GameObject.Find("Blood").SetActive(false);
        GameObject.Find("BulletTimeText").SetActive(false);
        GameObject.Find("Level").SetActive(false);
        GameObject.Find("ChromaticRing").GetComponent<Image>().DOFade(0, 0.5f);
        yourScore.SetActive(true);
        yourScore.transform.DOScale(new Vector3(1, 1, 0), 1f);
    }
}
