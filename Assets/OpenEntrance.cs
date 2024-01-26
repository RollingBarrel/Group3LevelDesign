using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEntrance : MonoBehaviour
{
    public float height;
    public float speed = 1;


    Transform door;
    bool inRange;
    float doorInitialPos;

    // Start is called before the first frame update
    void Start()
    {
        door = transform.GetChild(0);
        doorInitialPos = door.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        MoveDoor(door, inRange);
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

    void MoveDoor(Transform door, bool inRange)
    {
        if (inRange)
        {
            if (door.position.y > doorInitialPos - height)
            {
                door.position -= new Vector3(0, speed * Time.deltaTime, 0);
            }
        }
        else
        {
            if (door.position.y < doorInitialPos)
            {
                door.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
        }
    }
}
