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
    // Start is called before the first frame update
    void Start()
    {
        
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
            bool success = true;
            
            if (gameObject.GetComponent<InkCanvas>())
            {
                var paintObject = gameObject.GetComponent<InkCanvas>();

                success = paintObject.PaintUVDirect(brush, new Vector2(0.5f, 0.5f));
            }

            if (!success)
            {
                Debug.LogError("Paint Error");
            }
        }
    }
}
