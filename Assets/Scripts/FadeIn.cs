using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {

    private float t;
    public float lerpDuration;
    private float alpha;
    private float oriAlpha;
    private float fadeDir;
    private bool fadeIn;
    // Use this for initialization
    void Start()
    {
        t = 0f;
        oriAlpha = 0f;
        fadeDir = 1f;
        alpha = 0f;
        lerpDuration = 1f;
        fadeIn = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!fadeIn)
        {
            return;
        }
        else
        {
            t += Time.deltaTime;

            if (t <= lerpDuration)
            {
                t += Time.deltaTime;
                t = Mathf.Clamp01(t);
                alpha = Mathf.Lerp(oriAlpha, fadeDir, t / lerpDuration);
            }
            else
            {
                fadeIn = false;

            }

            transform.GetComponent<MeshRenderer>().material.color = new Color(transform.GetComponent<MeshRenderer>().material.color.r,
                                                                              transform.GetComponent<MeshRenderer>().material.color.g,
                                                                              transform.GetComponent<MeshRenderer>().material.color.b,
                                                                             alpha);
            //Debug.Log(alpha);
        }
    }

    public void StartFadeIn()
    {
        t = 0;
        fadeIn = true;
        //Debug.Log(transform.name);
    }
}
