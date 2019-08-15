using System;
using System.Collections;
using System.Collections.Generic;
using Es.InkPainter;
using UnityEngine;
using Es.InkPainter.Sample;
public class WallPainter : MonoBehaviour
{
    [SerializeField]
    private Brush brush;

    private Color bulletColor;

    private int collisionTime;

    public Texture[] textures;
    // Start is called before the first frame update
    void Start()
    {
        collisionTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bulletColor = GameObject.Find("ChromaticRing").GetComponent<ArcSlider>().outputColor;
        brush.Color = bulletColor;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            brush.Color = Color.blue;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            brush.Color = Color.yellow;
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        //i++;
        if (other.collider.tag == "bullet")
        {
            if (brush.Color == bulletColor)
            {
                Debug.Log("成功");
                Debug.Log(brush.ColorBlending);
            }
            bool success = true;
            
            if (gameObject.GetComponent<InkCanvas>())
            {
                var paintObject = gameObject.GetComponent<InkCanvas>();

                var brush0 = new Brush(textures[collisionTime], 0.5f, bulletColor);
                success = paintObject.PaintUVDirect(brush0, new Vector2(0.5f, 0.5f));
                collisionTime++;
                if (collisionTime > textures.Length - 1)
                {
                    collisionTime = 0;
                }
            }

            if (!success)
            {
                Debug.LogError("Paint Error");
            }
        }
    }
}