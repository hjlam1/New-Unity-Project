using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {

    private float t;
    public float lerpDuration;
    private float alpha;
    private float oriAlpha;
    private float fadeDir;
    private bool fadeOut;
    // Use this for initialization
    void Start () {
        t = 0f;
        oriAlpha = 1f;
        fadeDir = 0f;
        alpha = 1f;
        lerpDuration = 0.5f;
        fadeOut = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (!fadeOut)
        {
            return;
        }
        else {
            t += Time.deltaTime;

            if (t <= lerpDuration)
            {
                t += Time.deltaTime;
                t = Mathf.Clamp01(t);
                alpha = Mathf.Lerp(oriAlpha, fadeDir, t / lerpDuration);
            }
            else {
                fadeOut = false;

            }

            transform.GetComponent<MeshRenderer>().material.color = new Color(transform.GetComponent<MeshRenderer>().material.color.r,
                                                                              transform.GetComponent<MeshRenderer>().material.color.g,
                                                                              transform.GetComponent<MeshRenderer>().material.color.b,
                                                                              alpha);
            //Debug.Log(transform.GetComponent<MeshRenderer>().material.color.a);
            //Debug.Log(transform.name+"faded");
        }
    }

    public void StartFadeOut() {
        t = 0;
        fadeOut = true;
        //Debug.Log(transform.name);
        //StartCoroutine(ShowUp());
    }

    /*private IEnumerator ShowUp() {
        yield return new WaitForSeconds(lerpDuration+0.1f);
        transform.GetComponent<MeshRenderer>().material.color = new Color(transform.GetComponent<MeshRenderer>().material.color.r,
                                                                              transform.GetComponent<MeshRenderer>().material.color.g,
                                                                              transform.GetComponent<MeshRenderer>().material.color.b,
                                                                              1);
    }*/
}
