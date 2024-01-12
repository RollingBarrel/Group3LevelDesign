using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public float speed = 1;
    public float height = 1;

    Vector3 originalPosition;
    float timeModule2pi = 0;

    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timeModule2pi += Time.deltaTime * speed;
        timeModule2pi = timeModule2pi % (2*Mathf.PI);

        transform.position = new Vector3(originalPosition.x, originalPosition.y + (Mathf.Cos(timeModule2pi) -1)*height, originalPosition.z); 
    }
}
