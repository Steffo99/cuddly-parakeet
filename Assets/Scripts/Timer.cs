using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public double time_left;
	public bool running;
	public GameObject display_on;

	void Start () {
		time_left = 10d;
	}

	void Update () {
		if (running) {
			time_left -= Time.deltaTime;
			//Stop the timer at 0.000
			if (time_left <= 0d) {
				time_left = 0d;
				running = false;
			}
			//Update display before calling the time ran out function
			if (display_on != null) {
				display_on.GetComponent<Text> ().text = time_left.ToString("00.000");
			}
			//Call the time ran out function
			if (time_left <= 0d) {
				TimeRanOut ();
			}
		}
	}

	void TimeRanOut() {
	}
}
