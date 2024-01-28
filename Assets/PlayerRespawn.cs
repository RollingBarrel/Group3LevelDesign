using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public float treshold;
    public float x= -46.75f;
    public float y= 0.66f;
    public float z= -36.37f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y < treshold)
        {
            transform.position = new Vector3(x,y, z);
        }
    }
}
