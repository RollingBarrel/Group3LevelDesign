using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Windows;

public class Dash : MonoBehaviour
{
    ThirdPersonController moveScript;
    public float dashSpeed = 10;
    public float dashTime = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<ThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetKeyDown("e"))
        {
            
           
            StartCoroutine(DoDash());
            
        }
    }
    //
    IEnumerator DoDash()
    {
        float startTime = Time.time;
        float gravityAux = moveScript.Gravity;
        

        while (Time.time < startTime + dashTime)
        {
            moveScript.Gravity = 0;
            moveScript._controller.Move(moveScript.targetDirection * dashSpeed * Time.deltaTime );
            moveScript.Gravity = gravityAux;
            yield return null;
        }
    }
}
