using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayerFadeToblack : MonoBehaviour
{

    public int intelligence = 1;
    public int Stage;
    private int videoClips;
    public SimpleSerial thisSimpleSerial;
    public VideoPlayer VideoPlayer1;
    //public VideoPlayer VideoPlayer2;
    public VideoClip clip1;
    public VideoClip clip2;
    public VideoClip clip3;
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


    public VideoFadein thisFadein;
    public RandomSymbolSentence MakeSentence;
    public RandomSymbolSentence MakeNextSentence;

    public PDSentence proverb;
    public PDSentence direction;

    public GameObject Symbols;
    private bool StartTimer;

    private int connect;
    private int leftOn;
    private int rightOn;
    private IEnumerator StageThree;

    private bool stage4;
    public int preInt;
    public int preStage;

    public AudioSource Rumbling;

    void Start()
    {
        intelligence = 1;
        Stage = 1;
        stage4 = false;
        provebs = new VideoClip[] {
            Proverb1,Proverb2,Proverb3,Proverb4,Proverb5,Proverb6,Proverb7,Proverb8,Proverb9,Proverb10
        };

    }
    void Update()
    {
        //Stage = 3;
        StageThree = StartStageFour();
        //intelligence = thisSimpleSerial.reading;
        //intelligence = 3;
        connect = thisSimpleSerial.connected;
        leftOn = thisSimpleSerial.left;
        rightOn = thisSimpleSerial.right;

        if (connect == 0 && leftOn == 0 && rightOn == 0)
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
        }


        if (preStage == Stage)
        {
            return;
        }
        else
        {
            preStage = Stage;

            if (!stage4)
            {
                intelligence = intelligenceToStage();
            }
            else {
                intelligence = 4;
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
                //print("Stage 4");
                stage4 = true;
                StartCoroutine(VideoFadeIn(ProverbClip));
                StartCoroutine(StartStageOne());
                Debug.Log(ProverbClip.name);
                Rumbling.Stop();

                break;
            case 3:
                //print("Stage 3");
                StartCoroutine(VideoFadeIn(clip3));
                StartCoroutine(StageThree);

                int Index = Random.Range(0,9);
                ProverbClip = provebs[Index];

                MakeSentence.MakeRandomSymbolSentence();
                MakeNextSentence.MakeRandomSymbolSentence();

                proverb.MakeProver();
                direction.MakeDirection();

                Rumbling.Play();

                break;
            case 2:
                //("Stage 2");
                StartCoroutine(VideoFadeIn(clip2));
                Rumbling.Stop();
                if (!StartTimer)
                {
                    return;
                }
                else
                {
                    StopCoroutine(StageThree);
                }

                break;
            case 1:
                //print("Stage 1");
                VideoPlayer1.clip = clip1;
                Rumbling.Stop();
                Symbols.SetActive(false);
                StartCoroutine(VideoFadeIn(clip1));
                stage4 = false;
                break;
            default:
                //print("Stage 1");
                //thisVideo.Play();
                break;
        }
    }

    IEnumerator VideoFadeIn(VideoClip newClip)
    {
        float fadeTime = thisFadein.lerpDuration;
        thisFadein.BeginFade();
        VideoPlayer1.clip = newClip;

        yield return new WaitForSeconds(fadeTime);
        VideoPlayer1.Play();
        //VideoPlayer1.gameObject.SetActive();

        thisFadein.FadeOut();
    }

    IEnumerator StartStageFour()
    {
        Debug.Log("StartTimer");
        StartTimer = true;
        yield return new WaitForSeconds(6);
        intelligence = 4;
        StartCoroutine(StartSymbols());
        Stages();
        StartTimer = false;
    }

    IEnumerator StartStageOne()
    {
        Debug.Log("StartTimer");
        StartTimer = true;
        yield return new WaitForSeconds(6);
        intelligence = 1;
        Stages();
        StartTimer = false;
    }

    IEnumerator StartSymbols()
    {
        yield return new WaitForSeconds(2);
        Symbols.SetActive(true);
    }
}
