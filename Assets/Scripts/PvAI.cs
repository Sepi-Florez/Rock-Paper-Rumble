using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PvAI : MonoBehaviour {
	public Text countDown;


    public float timeLeft; 
	public float timeCount;
	public float waitTime = 1F;
	public bool counting = false;
    
    public enum Choice {Rock, Paper, Scissors, Null};
    public Choice playerChoice;
    public Choice aiChoice;

    public string player1_Name;
    public string player2_Name;
    public Text[] playerNames;

    private UI scriptUI;

    void Start () {
        scriptUI = transform.GetComponent<UI>();
		timeLeft = timeCount;
		countDown.text = timeLeft.ToString("0");
        playerNames[0].text = player1_Name;
        playerNames[1].text = player2_Name;

    }
	
	void Update () {
		if(Input.GetButtonDown("Jump")&& counting == false){
            scriptUI.counting = true;
            scriptUI.Outcome(0);
            timeLeft = timeCount;
            scriptUI.TimeChange(timeLeft.ToString("0f"));
            StartCoroutine(Timer());
            counting = true;
            playerChoice = (Choice)3;
            AIPick();
		}
        else if(counting == true) { 
            Pick();
        }
	}
    IEnumerator Timer() {
        yield return new WaitForSeconds(waitTime);
        timeLeft -= 1;
        scriptUI.TimeChange(timeLeft.ToString("F0"));
        if (timeLeft <= 0) {
            counting = false;
            WinCheck();
            scriptUI.ChoiceAI((int)aiChoice);
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
            scriptUI.Outcome(0);
            scriptUI.ChoiceP((int)aiChoice);
        }
        else {
            switch (playerChoice) {
                case (Choice)0:
                    scriptUI.Outcome(Check0());
                    scriptUI.ChoiceP(0);
                    break;
                case (Choice)1:
                    scriptUI.Outcome(Check1());
                    scriptUI.ChoiceP(1);
                    break;
                case (Choice)2:
                    scriptUI.Outcome(Check2());
                    scriptUI.ChoiceP(2);
                    break;
                case (Choice)3:
                    scriptUI.Outcome(2);
                    scriptUI.ChoiceP(3);
                    break;
            }
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
