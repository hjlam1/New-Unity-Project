using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageThreeTimer : MonoBehaviour {

    public Player player;
    private IEnumerator StageFour;
    private bool StartTimer;

    private float LoadTime;
    private float startLoadTime;
	// Use this for initialization
	void Start () {
        StageFour = StartStageFour();
        StartTimer = false;
    }
	
	// Update is called once per frame
	void Update () {
        
        
        if (transform.tag == "FrontVideo")
        {
            startLoadTime = Time.time;

            StartCoroutine(StageFour);
        }
        else {
            if (!StartTimer)
            {
                return;
            }
            else {
                StopCoroutine(StageFour);
            }
        }
	}

    IEnumerator StartStageFour() {
        StartTimer = true;
        yield return new WaitForSeconds(4);
        LoadTime = Time.time - startLoadTime;
        Debug.Log(LoadTime);
        player.intelligence = 4;
        StartTimer = false;
    }
}
