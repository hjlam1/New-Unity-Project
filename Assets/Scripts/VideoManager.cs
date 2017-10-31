using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{

    public int intelligence = 1;
    public int Stage;

    private int videoClips;
    public SimpleSerial thisSimpleSerial;
    public VideoPlayer VideoPlayer1;
    public VideoPlayer VideoPlayer2;
    public VideoPlayer VideoPlayer3;
    public VideoPlayer VideoPlayer4;

    public VideoClip Proverb1;
    public VideoClip Proverb2;
    public VideoClip Proverb3;
    public VideoClip Proverb4;
    public VideoClip Proverb5;
    public VideoClip Proverb6;
    public VideoClip Proverb7;
    public VideoClip Proverb8;
    public VideoClip Proverb9;
    public VideoClip Proverb10;

    private VideoClip[] provebs;
    private VideoClip ProverbClip;

    public RandomSymbolSentence MakeSentence;
    public RandomSymbolSentence MakeNextSentence;

    public PDSentence proverb;
    public PDSentence direction;

    private int connect;
    private int leftOn;
    private int rightOn;
    private IEnumerator StageThree;

    public int stage4Duration;
    public int stage3Duration;

    private VideoPlayer CurrentOne;
    private VideoPlayer NextOne;
    public GameObject Symbols;
    private bool StartTimer;

    public VideoClip clip4;
    private bool start;

    private float fadeTime;
    //public VideoFadein thisFadein;

    public AudioSource Rumbling;

    private bool stage4;
    private bool easying;
    private bool stage3;
    public int preInt;
    public int preStage;

    void Start()
    {
        intelligence = 1;
        Stage = 1;
        stage4 = false;
        stage3 = false;
        start = true;
        easying = false;

        provebs = new VideoClip[] {
            Proverb1,Proverb2,Proverb3,Proverb4,Proverb5,Proverb6,Proverb7,Proverb8,Proverb9,Proverb10
        };

        VideoPlayer1.transform.position = new Vector3(100f, 0f, .1f);
        VideoPlayer2.transform.position = new Vector3(100f, 0f, 0f);
        VideoPlayer3.transform.position = new Vector3(100f, 0f, .1f);
        VideoPlayer4.transform.position = new Vector3(100f, 0f, .1f);

    }
    void Update()
    {
        StageThree = StartStageFour();

        connect = thisSimpleSerial.connected;
        leftOn = thisSimpleSerial.left;
        rightOn = thisSimpleSerial.right;

        /*if (connect == 0 && leftOn == 0 && rightOn == 0)
       {
           Stage = 1;
       }
       else
       if (connect == 1 && leftOn == 1 && rightOn == 1)
       {
           Stage = 3;
       }
       else {
           Stage = 2;
       }*/

        if (stage3)
        {
            InputEveryFrame();
        }
        else {
            if (easying)
            {
                return;
            }
            else
            {
                StartCoroutine(EasyInput());
            }
        }

        if (preInt == intelligence)
        {
            return;
        }
        else
        {
            preInt = intelligence;
            //print("Stage()");
            Stages();
        }

    }

    private int intelligenceToStage()
    {
        intelligence = Stage;
        //Debug.Log("Called Stage:" + Stage);
        return intelligence;
    }

    void Stages()
    {
        switch (intelligence)
        {
            case 4:
                stage4 = true;
                stage3 = false;
                StartCoroutine(StartStageOne());
                fadeTime = VideoPlayer1.GetComponent<FadeIn>().lerpDuration;
                start = false;

                ReSetUpVideos(VideoPlayer4);

                Rumbling.Stop();
                StartCoroutine(CaseFour(fadeTime));
                break;
            case 3:
                stage3 = true;
                fadeTime = VideoPlayer1.GetComponent<FadeIn>().lerpDuration;
                start = false;
                StartCoroutine(StageThree);

                ReSetUpVideos(VideoPlayer3);

                int Index = Random.Range(0, 9);
                ProverbClip = provebs[Index];
                VideoPlayer4.clip = ProverbClip;
                VideoPlayer4.Play();

                MakeSentence.MakeRandomSymbolSentence();
                MakeNextSentence.MakeRandomSymbolSentence();

                proverb.MakeProver();
                direction.MakeDirection();

                Rumbling.Play();

                StartCoroutine(CaseThree(fadeTime));
                
                break;
            case 2:
                fadeTime = VideoPlayer1.GetComponent<FadeIn>().lerpDuration;
                stage3 = false;

                start = false;

                ReSetUpVideos(VideoPlayer2);

                Rumbling.Stop();

                StartCoroutine(CaseTwo(fadeTime));

                break;
            case 1:
                //print("Stage 1");
                fadeTime = VideoPlayer1.GetComponent<FadeIn>().lerpDuration;
                if (start)
                {
                    CurrentOne = VideoPlayer1;
                    NextOne = VideoPlayer2;

                    CurrentOne.transform.position = new Vector3(0f, 0f, 0f);
                    NextOne.transform.position = new Vector3(0f, 0f, -1f);

                    

                    NextOne.transform.GetComponent<MeshRenderer>().material.color = new Color(NextOne.transform.GetComponent<MeshRenderer>().material.color.r,
                                                                              NextOne.transform.GetComponent<MeshRenderer>().material.color.g,
                                                                              NextOne.transform.GetComponent<MeshRenderer>().material.color.b,
                                                                              0);
                    //return;
                }
                else
                {
                    stage4 = false;
                    stage3 = false;
                    //print("Stage 1" + CurrentOne);

                    Rumbling.Stop();

                    ReSetUpVideos(VideoPlayer1);

                    Symbols.SetActive(false);
                    //NextOne.GetComponent<FadeIn>().StartFadeIn();
                    StartCoroutine(CaseOne(fadeTime));
                }

                break;
            default:
                //print("Stage 1");
                break;
        }
    }

    private void InputEveryFrame() {
        if (preStage == Stage)
        {
            return;
        }
        else
        {
            if (Stage != 3) {
                StopCoroutine(StageThree);
                preStage = Stage;
                intelligence = intelligenceToStage();
            }
        }
    }

    private void ReSetUpVideos(VideoPlayer NextVideo) {
        NextOne = NextVideo;
        NextOne.transform.GetComponent<MeshRenderer>().material.color = new Color(NextOne.transform.GetComponent<MeshRenderer>().material.color.r,
                                                                      NextOne.transform.GetComponent<MeshRenderer>().material.color.g,
                                                                      NextOne.transform.GetComponent<MeshRenderer>().material.color.b,
                                                                      0);
        VideoPlayer1.transform.position = new Vector3(100f, 0f, .1f);
        VideoPlayer2.transform.position = new Vector3(100f, 0f, 0f);
        VideoPlayer3.transform.position = new Vector3(100f, 0f, .1f);
        VideoPlayer4.transform.position = new Vector3(100f, 0f, .1f);

        CurrentOne.transform.position = new Vector3(0f, 0f, 0f);
        NextOne.transform.position = new Vector3(0f, 0f, -1f);

        NextOne.GetComponent<FadeIn>().StartFadeIn();
    }

    private IEnumerator EasyInput() {
        easying = true;
        yield return new WaitForSeconds(.5f);
        //Debug.Log("EasyInput");
        if (preStage == Stage)
        {
           yield return new WaitForSeconds(0);
        }
        else
        {
            if (!stage4)
            {
                preStage = Stage;
                intelligence = intelligenceToStage();
            }
            else
            {
                intelligence = 4;
            }

        }

        easying = false;
    }



    private IEnumerator CaseOne(float fadeOutTime)
    {
        float fadeInTime = fadeOutTime - 0.5f;
        yield return new WaitForSeconds(fadeInTime);
        CurrentOne = VideoPlayer1;
    }

    private IEnumerator CaseTwo(float fadeOutTime)
    {
        float fadeInTime = fadeOutTime - 0.5f;
        yield return new WaitForSeconds(fadeInTime);
        CurrentOne = VideoPlayer2;
    }

    private IEnumerator CaseThree(float fadeOutTime)
    {
        float fadeInTime = fadeOutTime - 0.5f;
        yield return new WaitForSeconds(fadeInTime);
        CurrentOne = VideoPlayer3;
    }

    private IEnumerator CaseFour(float fadeOutTime)
    {
        float fadeInTime = fadeOutTime - 0.5f;
        yield return new WaitForSeconds(fadeInTime);
        CurrentOne = VideoPlayer4;
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

    private IEnumerator StartStageFour()
    {
        Debug.Log("StartTimer");
        StartTimer = true;
        yield return new WaitForSeconds(stage3Duration);
        
        if (Stage == 3)
        {
            Debug.Log("StopedTimer");
            intelligence = 4;
            StartCoroutine(StartSymbols());
            Stages();
            StartTimer = false;
        }
        else {
            Debug.Log("CanceledTimer");
            yield return new WaitForSeconds(0);
        }

        
    }

    private IEnumerator StartStageOne()
    {
        //StartTimer = true;
        yield return new WaitForSeconds(stage4Duration);
        intelligence = 1;
        Stages();
        //StartTimer = false;
    }

    IEnumerator StartSymbols()
    {
        yield return new WaitForSeconds(2);
        Symbols.SetActive(true);
    }

}
