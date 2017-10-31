using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFourTimer : MonoBehaviour {

    public Player player;
    private IEnumerator StageOne;
    private bool StartTimer;

    private float LoadTime;
    private float startLoadTime;
    // Use this for initialization
    void Start()
    {
        StageOne = StartStageOne();
        StartTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (transform.tag == "FrontVideo")
        {
            startLoadTime = Time.time;

            StartCoroutine(StageOne);
        }
        else
        {
            if (!StartTimer)
            {
                return;
            }
            else
            {
                StopCoroutine(StageOne);
            }
        }
    }

    IEnumerator StartStageOne()
    {
        StartTimer = true;
        yield return new WaitForSeconds(6);
        LoadTime = Time.time - startLoadTime;
        Debug.Log(LoadTime);
        player.intelligence = 1;
        StartTimer = false;
    }
}
