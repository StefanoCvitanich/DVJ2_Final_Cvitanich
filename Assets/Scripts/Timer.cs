using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	private float timer;
	private float minutes;
	private float seconds;

	private Text timerText;

	// Use this for initialization
	void Start () {

		timerText = gameObject.GetComponent<Text> () as Text;
	}
	
	// Update is called once per frame
	void Update () {

		timer = Time.timeSinceLevelLoad;

		minutes = (int)(timer / 60.0f);
		seconds = (int)(timer % 60.0f);

		timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
	}
}
