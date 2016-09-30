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
    public enum Choice {Rock, Paper, Scissors};
    public Choice playerChoice;
    public Choice aiChoice;
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
            AIPick();
		}
        else if(counting == true) { 
            Pick();
        }
	}
    IEnumerator Timer() {
        yield return new WaitForSeconds(waitTime);
        timeLeft -= 1;
        countDown.text = timeLeft.ToString("F0");
        if (timeLeft <= 0) {
            timeUp.gameObject.SetActive(true);
            counting = false;
            StopCoroutine(Timer());
        }
        else {
            StartCoroutine(Timer());
        }
    }
    void Pick () {
        switch (Input.inputString) {
            case "q":
                print("Rock");
                playerChoice = (Choice)0;
                break;

            case "w":
                print("Paper");
                playerChoice = (Choice)1;
                break;

            case "e":
                print("Scissors");
                playerChoice = (Choice)2;
                break;
        }
    }
    void AIPick() {
        aiChoice = (Choice)Random.Range(0, 3);
    }

}
