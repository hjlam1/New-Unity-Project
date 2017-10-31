using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoFadein : MonoBehaviour
{
    public Texture2D fadeOutTexture;
    private int drawDepth = 1000;
    private float alpha = 1.0f;
    private float oriAlpha = 0f;
    private float fadeDir = 1;
    private bool startFading = true;

    private float current = 0f;
    public float lerpDuration;
    private bool fadeOut;

    void OnGUI()
    {
        //alpha += fadeDir * fadeSpeed * Time.deltaTime;
        //alpha = Mathf.Clamp01(alpha);
        //fadeTime = Time.deltaTime;
        //alpha = Mathf.Lerp(oriAlpha, fadeDir, fadeTime);
        alpha = FadeTime();
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public void BeginFade()
    {
        current = 0f;
        oriAlpha = 0f;
        fadeDir = 1f;
        startFading = true;
    }

    public void FadeOut()
    {
        current = 0f;
        oriAlpha = 1f;
        fadeDir = 0f;
        startFading = true;
    }

    private float FadeTime()
    {
        if (!startFading)
        {

            return alpha;
        }
        else
        {
            if (current <= lerpDuration)
            {
                current += Time.deltaTime;
                alpha = Mathf.Lerp(oriAlpha, fadeDir, current / lerpDuration);
            }
            else
            {
                startFading = false;
            }
        }

        return alpha;
    }
}
