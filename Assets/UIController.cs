using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    private float startTime = 15.00f;
    private float time;
    private float overTime = 0;
    private float timeflat;
    private GameObject timeWatchText;
    private GameObject timeUPText;

    // ゲーム終了の判定
    private bool isEnd = false;

    // Use this for initialization
    void Start ()
    {
        this.time = 0;
        this.timeflat = 0;
        this.timeWatchText = GameObject.Find("TimeWatchText");
        this.timeUPText = GameObject.Find("TimeUPText");


    }
	
	// Update is called once per frame
	void Update () {
        this.timeflat += Time.deltaTime;
        this.time = startTime - timeflat;
        this.timeWatchText.GetComponent<Text>().text = time.ToString("F2");

        if(time <= overTime)
        {
            this.time = 0;
            this.timeflat = 0;
            this.timeUPText.GetComponent<Text>().text = "TimeUP";
        }
    }
}
