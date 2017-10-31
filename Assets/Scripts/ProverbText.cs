using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProverbText : MonoBehaviour {

    public bool turnOnText;
    public GameObject proverb;
	// Use this for initialization
	void Start () {
        turnOnText = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!turnOnText)
        {
            return;
        }
        else {
            proverb.SetActive(true);
        }
	}
}
