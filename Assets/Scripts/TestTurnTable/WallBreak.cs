using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WallBreak : MonoBehaviour
{
    //墙的生命值
    private float health = 200.0f;

    //是否打破
    public static bool hitWall;

    public GameObject road;
    
    private GameObject camera;

    public GameObject bigWall;

    private SoundEffectsInGame soundEffectsInGame;

    private float fadeSpeed = 0.0f;

    private float sphereFadeSpeed = 0.0f;

    private float sphereExtendSpeed = 0.0f;
    
    private float wallH, wallS, wallL;
    
    private float damage = 0;

    public static int yourScore = 0;

    private bool isOneshot;

    public static bool falseShoot;
    
    public Image bloodImage;
    public GameObject particles;
    private AudioSource AudioSource;

    private Text level;
    
    private Text rewardText;

    // Start is called before the first frame update
    void Start()
    {
        soundEffectsInGame = GameObject.Find("LevelSeletor").GetComponent<SoundEffectsInGame>();
        camera=GameObject.FindWithTag("MainCamera");
        AudioSource = GameObject.Find("LevelSeletor").GetComponent<AudioSource>();
        rewardText = GameObject.Find("RewardText").GetComponent<Text>();
        level = GameObject.Find("Level").GetComponent<Text>();
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.collider.tag == "bullet")
        //{
        //    if (collision.collider.gameObject.GetComponent<MeshRenderer>().materials[0].color == this.GetComponent<MeshRenderer>().materials[0].color)  
        //    {
        //        Debug.Log("同色");
        //        Destroy(collision.collider.gameObject);
        //        Destroy(this.gameObject);
        //    }
        //    else
        //    {
        //        Destroy(collision.collider.gameObject);
        //    }
        //}

        if(collision.collider.tag == "bullet")
        {
            Instantiate(particles, this.transform.position + new Vector3(0, 0, -2.5f), Quaternion.identity);
            Destroy(collision.collider.gameObject);
            
            //gameObject.GetComponent<Renderer>().material.SetFloat("_DissolveCutoff",0.1f);
            //this.AudioSource.PlayOneShot(soundEffectsInGame.soundEffects[1], 1.0f);

            if (gameObject.tag != "emptyWall")
            {
                JudgeColor(collision.collider.gameObject.GetComponent<MeshRenderer>().materials[0].color);
            }
            if (health <= 0 && gameObject.tag != "emptyWall")
            {
/*              
                Destroy(collision.collider.gameObject);
*/
                falseShoot = false;
                yourScore++;
                level.text = yourScore.ToString()+"层";
                gameObject.transform.DOLocalRotate(new Vector3(-90, 0, 0), 0.5f);

                gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, 
                    gameObject.transform.localPosition.y - gameObject.transform.GetComponent<BoxCollider>().size.y / 2,
                    gameObject.transform.localPosition.z - gameObject.transform.GetComponent<BoxCollider>().size.y / 5);


                fadeSpeed = Mathf.Lerp(fadeSpeed, 0.45f,1.0f);
                gameObject.GetComponent<Renderer>().material.SetFloat("_DissolveCutoff", fadeSpeed);

                StartCoroutine(Fall());

                hitWall = true;
            }
            else if (health <= 0 || gameObject.tag == "emptyWall")
            {
/*
                Destroy(collision.collider.gameObject);
*/
            }
        }
        if (collision.collider.tag == "Player")
        {
            this.AudioSource.PlayOneShot(soundEffectsInGame.soundEffects[1], 0.1f);
        }
    }

    private float JudgeColor(Color color)
    {
        float ballH, ballS, ballL;
        Color.RGBToHSV(color, out ballH, out ballS, out ballL);
        if(bigWall != null)
            Color.RGBToHSV(bigWall.GetComponent<MeshRenderer>().materials[0].color, out wallH, out wallS,out wallL);

        wallL *= 100;
        ballL *= 100;

        if (wallL - ballL > -2 && wallL - ballL < 2)
        {
            damage = 200;
            isOneshot = true;
            UIManager.bulletTime += 2;
            rewardText.DOFade(1, 0.1f);
            rewardText.DOText("+2", 0.1f);
            rewardText.DOFade(0, 1.5f);
        }
        else if (wallL - ballL > -4 && wallL - ballL < 4)
        {
            damage = 180;
            falseShoot = true;
            Examiner.Makeup -= 0.06f;
        }
        else if (wallL - ballL > -6 && wallL - ballL <6)
        {
            damage = 150;
            falseShoot = true;
            Examiner.Makeup -= 0.06f;

        }
        else if (wallL - ballL > -8 && wallL - ballL <8)
        {
            damage = 130;
            falseShoot = true;
            Examiner.Makeup -= 0.06f;

        }
        else if (wallL - ballL > -10 && wallL - ballL <10)
        {
            damage = 100;
            falseShoot = true;
            Examiner.Makeup -= 0.06f;

        }
        else if (wallL - ballL > -12 && wallL - ballL < 12)
        {
            damage = 80;
            falseShoot = true;
            Examiner.Makeup -= 0.06f;
        }
        else if (wallL - ballL > -14 && wallL - ballL <14)
        {
            damage = 60;
            falseShoot = true;
            Examiner.Makeup -= 0.06f;

        }
        else if (wallL - ballL > -16 && wallL - ballL <16)
        {
            damage = 40;
            falseShoot = true;
            Examiner.Makeup -= 0.06f;

        }
        else if (wallL - ballL > -18 && wallL - ballL <18)
        {
            damage = 30;
            falseShoot = true;
            Examiner.Makeup -= 0.06f;

        }
        else if (wallL - ballL > -20 && wallL - ballL <20)
        {
            damage = 10;
            falseShoot = true;
            Examiner.Makeup -= 0.06f;

        }
        else
        {
            damage = 0;
            falseShoot = true;
            Examiner.Makeup -= 0.06f;
        }

        StartCoroutine(SetFalseShoot());
        
        health -= damage;
       
        bloodImage.fillAmount = health / 200;
        return health;
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(0.3f);
        if (isOneshot)
        {
            AudioSource.PlayOneShot(soundEffectsInGame.soundEffects[3], 0.1f);
        }
        else
        {
            AudioSource.PlayOneShot(soundEffectsInGame.soundEffects[2], 0.1f);
        }
        Destroy(gameObject);
    }

    IEnumerator SetFalseShoot()
    {
        yield return new WaitForSeconds(0.5f);
        falseShoot = false;
    }


}
