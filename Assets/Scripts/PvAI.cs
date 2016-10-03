using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PvAI : MonoBehaviour {
	public Text countDown;
	public Text timeUp;
    public Text winText;
    public string[] winTextOptions;

    public float timeLeft; 
	public float timeCount;
	public float waitTime = 1F;
	public bool counting = false;
    
    public enum Choice {Rock, Paper, Scissors};
    public Choice playerChoice;
    public Choice aiChoice;

    public int player1Score;
    public int player2Score;

    void Start () {
        winText.gameObject.SetActive(false);
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
            UI(0);
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
            counting = false;
            WinCheck();
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
    void WinCheck () {
        if(playerChoice == aiChoice) {
            UI(0);
        }
        else {
            switch (playerChoice) {
                case (Choice)0:
                    UI(Check0());
                    break;
                case (Choice)1:
                    UI(Check1());
                    break;
                case (Choice)2:
                    UI(Check2());
                    break;
            }
        }
    }
    void UI (int outcome) {
        print("ui change");
        if(counting == false) {
            timeUp.gameObject.SetActive(true);
            winText.gameObject.SetActive(true);
            winText.text = winTextOptions[outcome];
        }
        else {
            timeUp.gameObject.SetActive(false);
            winText.gameObject.SetActive(false);
        }
    }
    int Check0 () {
        if(aiChoice == (Choice)2) {
            return 1;
        }
        else {
            return 2;
        }
    }
    int Check1() {
        if (aiChoice == (Choice)0) {
            return 1;
        }
        else {
            return 2;
        }
    }
    int Check2() {
        if (aiChoice == (Choice)1) {
            return 1;
        }
        else {
            return 2;
        }
    }
}
