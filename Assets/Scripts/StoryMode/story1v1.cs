using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class story1v1 : MonoBehaviour
{
    /*
     * 白模数组
     */
    public GameObject[] groups;

    //计时器
    private double Ticker = 3;

    //计数器
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Ticker -= Time.deltaTime;
        //if(Ticker < 0)
        //{
        //    Destroy(groups[counter]);
        //    Ticker = 3;
        //    if(counter < groups.Length)
        //    {
        //        counter += 1;
        //    } else
        //    {
        //        return;
        //    }
            
        //}
    }
}
