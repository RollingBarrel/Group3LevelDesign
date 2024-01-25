using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class MoveCovers : MonoBehaviour
{
    public float speed = 1;
    public float coolDown = 5;
    public float height = 1;
    private float movement = 0;
    private bool up = false ,  startCounter = false;
    private float timePassed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (movement >= height)
        {
            startCounter = true;
            movement = 0;
            up = up ? false : true;
        }
        

        if (startCounter)
        {
            timePassed += Time.deltaTime;

            if (timePassed >= coolDown)
            {
                timePassed = 0;
                startCounter = false;
            }
        }
        else
        {
            movement += speed * Time.deltaTime;
            if (up)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            }
        }

      
        
        
    }


   
   
}
