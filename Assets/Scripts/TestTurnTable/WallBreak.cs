﻿using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WallBreak : MonoBehaviour
{
    //墙的生命值
    private int health = 200;

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
    
    private int damage = 0;

    public static int yourScore = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        soundEffectsInGame = GameObject.Find("LevelSeletor").GetComponent<SoundEffectsInGame>();

    }

    // Update is called once per frame
    void Update()
    {
        
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
            Destroy(collision.collider.gameObject);
            
            //gameObject.GetComponent<Renderer>().material.SetFloat("_DissolveCutoff",0.1f);
            AudioSource.PlayClipAtPoint(soundEffectsInGame.soundEffects[0], transform.position);
            
            JudgeColor(collision.collider.gameObject.GetComponent<MeshRenderer>().materials[0].color);
            if (health <= 0 && gameObject.tag != "emptyWall")
            {
/*              
                Destroy(collision.collider.gameObject);
*/
                yourScore++;
                gameObject.transform.DOLocalRotate(new Vector3(-90, 0, 0), 0.5f);

                gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, 
                    gameObject.transform.localPosition.y - gameObject.transform.GetComponent<BoxCollider>().size.y / 2,
                    gameObject.transform.localPosition.z - gameObject.transform.GetComponent<BoxCollider>().size.y / 5);


                fadeSpeed = Mathf.Lerp(fadeSpeed, 0.45f,1.0f);
                gameObject.GetComponent<Renderer>().material.SetFloat("_DissolveCutoff", fadeSpeed);
                
/*
                road.GetComponent<MeshRenderer>().materials[0].color =
                    gameObject.GetComponent<MeshRenderer>().materials[0].color;
*/

                //gameObject.GetComponent<MeshRenderer>().materials[0].shader = Shader.Find("Standard");
                
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
            AudioSource.PlayClipAtPoint(soundEffectsInGame.soundEffects[0], transform.position);
        }
    }

    private int JudgeColor(Color color)
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
        }
        else if (wallL - ballL > -5 && wallL - ballL < 5)
        {
            damage = 100;
        }
        else if (wallL - ballL > -10 && wallL - ballL <10)
        {
            damage = 50;
        }
        else
        {
            damage = 0;
        }


        health -= damage;
        Debug.Log(health);
        Debug.Log(wallL - ballL);
        return health;
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}