using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMood : MonoBehaviour {

	public Sprite[] moods;
	int currentMood = 0;

	public void ChangeMood(int code){
		if (code >= 0 && code < moods.Length) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = moods [code];
			currentMood = code;
		}
	}

	public void ChangeWorst(){
		if (currentMood != moods.Length - 1) {
			currentMood++;
			gameObject.GetComponent<SpriteRenderer> ().sprite = moods [currentMood];
		}
	}

	public void ChangeBest(){
		if (currentMood != 0) {
			currentMood--;
			gameObject.GetComponent<SpriteRenderer> ().sprite = moods [currentMood];
		}
	}
}
