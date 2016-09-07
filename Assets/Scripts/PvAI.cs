using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PvAI : MonoBehaviour {
	public Text countDown;
	public Text timeUp;
	public float timeLeft; 
	public float timeCount;
	public float waitTime = 1F;
	public bool counting = false;
	void Start () {
		
		timeLeft = timeCount;
		countDown.text = timeLeft.ToString("0");
	}
	
	void Update () {
		if(Input.GetButtonDown("Jump")&& counting == false){	
			StartCoroutine(Timer());
			timeUp.gameObject.SetActive(false);
			timeLeft = timeCount;
			countDown.text = timeLeft.ToString("F0");
			counting = true;	
		}
	}
	IEnumerator Timer () {
		yield return new WaitForSeconds(waitTime);
		timeLeft -= 1;
		countDown.text = timeLeft.ToString("F0");
		if(timeLeft <= 0){
			timeUp.gameObject.SetActive(true);
			counting = false;
			StopCoroutine(Timer());
		}
		else{
			StartCoroutine(Timer());
		}	
	}
	void Pick () {
		
	}
}
