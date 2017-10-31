using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSymbolSentence : MonoBehaviour {

    public Sprite S1;
    public Sprite S2;
    public Sprite S3;
    public Sprite S4;
    public Sprite S5;
    public Sprite S6;
    public Sprite S7;
    public Sprite S8;
    public Sprite S9;
    public Sprite S10;
    public Sprite S11;
    public Sprite S12;
    public Sprite S13;
    public Sprite S14;
    public Sprite S15;
    public Sprite S16;
    public Sprite S17;
    public Sprite S18;
    public Sprite S19;
    public Sprite S20;
    public Sprite S21;
    public Sprite S22;
    public Sprite S23;
    public Sprite S24;
    public Sprite S25;

    private Sprite[] Ss;

    public RandomSymbolSentence checkSame;
    public int SIndext;

    public void MakeRandomSymbolSentence() {
        Ss = new Sprite[] {S1,S2,S3,S4,S5,S6,S7,S8,S9,S10,S11,S12,S13,S14,S15,S16,S17,S18,S19,S20,S21,S22,S23,S24,S25 };
        SIndext = Random.Range(0,24);
        if (SIndext == checkSame.SIndext) {
            checkSame.MakeRandomSymbolSentence();
        }
        GetComponent<Image>().sprite = Ss[SIndext];

    }
}
