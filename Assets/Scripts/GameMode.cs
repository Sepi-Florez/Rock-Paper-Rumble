using UnityEngine;
using System.Collections;

public class GameMode : MonoBehaviour {
	public void Selection (int selection) {
		if(selection == 1){
			Application.LoadLevel("Pvp");
		}
		else{
			Application.LoadLevel("PvAI");
		}
	}
}