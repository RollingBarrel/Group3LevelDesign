using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class OpenEntrance : MonoBehaviour
{
    public float movement;
    public float speed = 1;


    Transform doorLeft;
    float doorLeftInitialPos;
    Transform doorRight;
    float doorRightInitialPos;

    bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        doorLeft = transform.GetChild(0);
        doorLeftInitialPos = doorLeft.position.z;
        doorRight = transform.GetChild(1);
        doorRightInitialPos = doorRight.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        MoveDoor(doorRight, doorLeft, inRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
        }
    }

    void MoveDoor(Transform right, Transform left, bool inRange)
    {
        float doorPosZ = left.position.z;
        Vector3 move = new Vector3(0, 0, speed * Time.deltaTime);

        if (inRange)
        {
            if (doorPosZ > doorLeftInitialPos - movement)
            {
                left.position -= move;
                right.position += move;
            }
        }
        else
        {
            if (doorPosZ < doorLeftInitialPos)
            {
                left.position += move;
                right.position -= move;
            }
        }
    }
}
