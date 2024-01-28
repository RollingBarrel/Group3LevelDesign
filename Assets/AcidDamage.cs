using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcidDamage : MonoBehaviour
{
    [Header ("Damage Overlay")]
    public Image overlay;
    public float Duration;
    public float fadeSpeed;

    private float durationTimer;
    // Start is called before the first frame update
    void Start()
    {
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (overlay.color.a > 0)
        {
            durationTimer += Time.deltaTime;
            if (durationTimer>Duration)
            {
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha); 

            }
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Acid")
        {
            durationTimer = 0;
            overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1);
        }
    }

}
