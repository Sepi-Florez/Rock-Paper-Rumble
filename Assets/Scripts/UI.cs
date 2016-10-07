using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UI : MonoBehaviour {

    public Text time_UI;
    public Text win_UI;

    public GameObject timeUp;
    public GameObject[] choices;
    public GameObject[] choicesAI;

    public Text p1ScoreText;
    public Text p2ScoreText;
    public int p1Score;
    public int p2Score;

    public bool counting;

    public string[] winTextOptions;

    public void Awake () {
        print("choice disable");
        win_UI.gameObject.SetActive(false);
        for (int a = 0; a < choices.Length; a++) {
            choices[a].SetActive(false);
            if(a > 0)
                choicesAI[a - 1].SetActive(false);
            
        }
    }


    public void TimeChange(string time) {
        print(time);
        if (time == "0") {
            time_UI.text = time;
            counting = false;
            print("time change");
        }
        else {
            time_UI.text = time;
            counting = true;
            print("time end");
        }
    }
    public void Outcome(int outcome) {
        print("ui change");
        if (counting) {
            timeUp.gameObject.SetActive(false);
            win_UI.gameObject.SetActive(false);
            for (int a = 0; a < choices.Length; a++) {
                choices[a].SetActive(false);
                if (a > 0)
                    choicesAI[a - 1].SetActive(false);
            }
        }
        else {
            win_UI.gameObject.SetActive(true);
            timeUp.SetActive(true);
            win_UI.text = winTextOptions[outcome];
            print("disable");
            if(counting == 1) {
                p1ScoreText.text = p1Score;

            }
            else {

            }

        }
    }
    public void ChoiceP(int choice) {
        choices[choice].SetActive(true);
    }
    public void ChoiceAI(int choice) {
        choicesAI[choice].SetActive(true);
    }
}
