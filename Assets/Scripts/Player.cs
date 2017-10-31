using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Player : MonoBehaviour
{
    public int intelligence = 1;
    private int videoClips;
    public SimpleSerial thisSimpleSerial;
    public VideoPlayer VideoPlayer1;
    public VideoPlayer VideoPlayer2;
    public VideoPlayer VideoPlayer3;
    public VideoPlayer VideoPlayer4;

    private VideoPlayer CurrentOne;
    private VideoPlayer NextOne;
    //public VideoClip clip1;
    //public VideoClip clip2;
    //public VideoClip clip3;
    public VideoClip clip4;
    private bool start;

    private float fadeTime;
    //public VideoFadein thisFadein;

    public int preInt;

    void Start()
    {
        intelligence = 1;
        fadeTime = VideoPlayer1.GetComponent<FadeOut>().lerpDuration;
        start = true;
        //VideoPlayer1.clip = clip1;
        //VideoPlayer2.clip = clip2;
        //VideoPlayer3.clip = clip3;

        CurrentOne = VideoPlayer1;
        NextOne = VideoPlayer2;


        VideoPlayer1.gameObject.tag = "FrontVideo";

        CurrentOne.transform.position = new Vector3(0f, 0f, -.1f);
        NextOne.transform.position = new Vector3(0f, 0f, 0f);


        VideoPlayer1.transform.position = new Vector3(10f, 0f, .1f);
        VideoPlayer2.transform.position = new Vector3(10f, 0f, 0f);
        VideoPlayer3.transform.position = new Vector3(10f, 0f, .1f);
        VideoPlayer4.transform.position = new Vector3(10f, 0f, .1f);
    }
    void Update()
    {
        //intelligence = thisSimpleSerial.reading;
        if (preInt == intelligence)
        {
            return;
        }
        else
        {
            preInt = intelligence;
            Stages();
        }

    }

    void Stages()
    {
        switch (intelligence)
        {
            case 4:
                print("Stage 4");

                //NextOne = VideoPlayer4;

                //VideoPlayer3.GetComponent<FadeOut>().StartFadeOut();
                StartCoroutine(CaseFour(fadeTime));
                break;
            case 3:
                //print("Stage 3");
                //Player loading video and pick Case 4 video
                start = false;

                //NextOne = VideoPlayer3;


                //GameObject.FindGameObjectWithTag("FrontVideo").GetComponent<FadeOut>().StartFadeOut();
                StartCoroutine(CaseThree(fadeTime));


                videoClips = Random.Range(1, 10);
                VideoCollection();
                break;
            case 2:
                //print("Stage 2");
                //StartCoroutine(VideoFadeIn(clip2));
                start = false;

                //NextOne = VideoPlayer2;

                //GameObject.FindGameObjectWithTag("FrontVideo").GetComponent<FadeOut>().StartFadeOut();
                StartCoroutine(CaseTwo(fadeTime));

                break;
            case 1:
                //print("Stage 1");
                if (start)
                {
                    return;
                }
                else
                {

                    NextOne = VideoPlayer1;


                    GameObject.FindGameObjectWithTag("FrontVideo").GetComponent<FadeOut>().StartFadeOut();
                    StartCoroutine(CaseOne(fadeTime));
                }


                //StartCoroutine(VideoFadeIn(clip1));
                break;
            default:
                print("Stage 1");

                //thisVideo.Play();
                break;
        }
    }

    void VideoCollection()
    {
        switch (videoClips)
        {
            case 10:
                print("Video 10");
                break;
            case 9:
                print("Video 9");
                break;
            case 8:
                print("Video 8");
                break;
            case 7:
                print("Video 7");
                break;
            case 6:
                print("Video 6");
                break;
            case 5:
                print("Video 5");
                break;
            case 4:
                print("Video 4");
                break;
            case 3:
                print("Video 3");
                break;
            case 2:
                print("Video 2");
                break;
            case 1:
                print("Video 1");
                break;
            default:
                print("Stage 1");
                break;
        }
    }
    //Fade to Black
    /*private IEnumerator VideoFadeIn(VideoClip newClip) {
        //float fadeTime = thisFadein.lerpDuration;
        //thisFadein.BeginFade();
        //VideoPlayer1.clip = newClip;
        //VideoPlayer1.Play();
        yield return new WaitForSeconds(1f);
        //VideoPlayer1.gameObject.SetActive()

        //thisFadein.FadeOut();
    }*/



    private IEnumerator CaseOne(float fadeOutTime)
    {
        //Debug.Log("fadeOutTime is " + fadeOutTime);
        yield return new WaitForSeconds(fadeOutTime);
        CurrentOne = VideoPlayer1;

        



        /*VideoPlayer1.gameObject.tag = "FrontVideo";
        VideoPlayer2.gameObject.tag = "Untagged";
        VideoPlayer3.gameObject.tag = "Untagged";
        VideoPlayer4.gameObject.tag = "Untagged";

        VideoPlayer1.transform.position = new Vector3(0f, 0f, -.1f);
        VideoPlayer2.transform.position = new Vector3(0f, 0f, 0f);
        VideoPlayer3.transform.position = new Vector3(0f, 0f, .1f);
        VideoPlayer4.transform.position = new Vector3(0f, 0f, .2f);*/
    }

    private IEnumerator CaseTwo(float fadeOutTime)
    {
        yield return new WaitForSeconds(fadeOutTime);
        VideoPlayer2.gameObject.tag = "FrontVideo";
        VideoPlayer1.gameObject.tag = "Untagged";
        VideoPlayer3.gameObject.tag = "Untagged";
        VideoPlayer4.gameObject.tag = "Untagged";

        VideoPlayer2.transform.position = new Vector3(0f, 0f, -.1f);
        VideoPlayer1.transform.position = new Vector3(0f, 0f, 0f);
        VideoPlayer3.transform.position = new Vector3(0f, 0f, .1f);
        VideoPlayer4.transform.position = new Vector3(0f, 0f, .2f);
    }

    private IEnumerator CaseThree(float fadeOutTime)
    {
        yield return new WaitForSeconds(fadeOutTime);
        VideoPlayer3.gameObject.tag = "FrontVideo";
        VideoPlayer1.gameObject.tag = "Untagged";
        VideoPlayer2.gameObject.tag = "Untagged";
        VideoPlayer4.gameObject.tag = "Untagged";

        VideoPlayer3.transform.position = new Vector3(0f, 0f, -.1f);
        VideoPlayer1.transform.position = new Vector3(0f, 0f, 0f);
        VideoPlayer2.transform.position = new Vector3(0f, 0f, .1f);
        VideoPlayer4.transform.position = new Vector3(0f, 0f, .2f);
    }

    private IEnumerator CaseFour(float fadeOutTime)
    {
        yield return new WaitForSeconds(fadeOutTime);
        VideoPlayer4.gameObject.tag = "FrontVideo";
        VideoPlayer1.gameObject.tag = "Untagged";
        VideoPlayer2.gameObject.tag = "Untagged";
        VideoPlayer3.gameObject.tag = "Untagged";

        VideoPlayer4.transform.position = new Vector3(0f, 0f, -.1f);
        VideoPlayer1.transform.position = new Vector3(0f, 0f, 0f);
        VideoPlayer2.transform.position = new Vector3(0f, 0f, .1f);
        VideoPlayer3.transform.position = new Vector3(0f, 0f, .2f);
    }

    //For Debug usage
    public void PlayerVideoOne()
    {
        intelligence = 1;
    }
    public void PlayerVideoTwo()
    {
        intelligence = 2;
    }
    public void PlayerVideoThree()
    {
        intelligence = 3;
    }
    public void PlayerVideoFour()
    {
        intelligence = 4;
    }
}
