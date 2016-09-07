using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PvAI : MonoBehaviour {
	public Text countDown;
	public Text timeUp;
	public float timeLeft = 10f; 
	public bool counting = false;
	void Start () {
	
	}
	
	void Update () {
		if(counting == true){
			Timer();
		}
		else{
			if(Input.GetButtonDown("Jump")){
				counting = true;
				timeLeft = 10;
				timeUp.gameObject.SetActive(false);
			}
		}
	}
	void Timer () {
		timeLeft -= Time.deltaTime;
		countDown.text = timeLeft.ToString();
		if(timeLeft <= 0){
			timeUp.gameObject.SetActive(true);
			counting = false;
		}
	}
}
