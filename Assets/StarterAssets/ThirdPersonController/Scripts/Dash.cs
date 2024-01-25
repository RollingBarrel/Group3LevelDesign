using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Windows;

public class Dash : MonoBehaviour
{
    ThirdPersonController moveScript;
    public float dashSpeed = 10;
    public float verticalDashForce;
    public float dashTime = 0.25f;
    public float coolDown = 2;
    private float counter = 0;
    private bool isDashEnabled = true;


    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<ThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashEnabled)
        {
            if (UnityEngine.Input.GetKeyDown("e"))
            {
                StartCoroutine(DoDash());
                isDashEnabled = false;
            }
        }
        else
        {
            if (counter >= coolDown)
            {
                isDashEnabled = true;
                counter = 0;
            }
            else
            {
                counter += Time.deltaTime;
            }

        }



    }
    //
    IEnumerator DoDash()
    {
        float startTime = Time.time;



        while (Time.time < startTime + dashTime)
        {
            moveScript._controller.Move(moveScript.transform.forward * dashSpeed * Time.deltaTime);
            moveScript._controller.Move(new float3(0, 1, 0) * verticalDashForce * Time.deltaTime);
            yield return null;
        }
    }
}
