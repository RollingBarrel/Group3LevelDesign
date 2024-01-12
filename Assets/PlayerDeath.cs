using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    Vector3 initialPlayerposition;

    // Start is called before the first frame update
    void Start()
    {
        initialPlayerposition = transform.position;
        Debug.Log(initialPlayerposition.x + " " + initialPlayerposition.y + " " + initialPlayerposition.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Death")
        {
            Vector3 respawn = transform.position - initialPlayerposition;
            transform.position = initialPlayerposition;
            Debug.Log(other.transform.tag + " " + initialPlayerposition.x + " " + initialPlayerposition.y + " " + initialPlayerposition.z);
        }
        else
        {
            Debug.Log(other.transform.tag);
        }
    }
}
