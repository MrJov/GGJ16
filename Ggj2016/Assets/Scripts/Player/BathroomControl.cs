using UnityEngine;
using System.Collections;

public class BathroomControl : MonoBehaviour {

	public string buttonA;
	public string buttonB;
	public string buttonX;
	public string buttonY;
	int sequenceLength;
	int placedItems = 0;
	string[] sequence;
	bool sequenceReady = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!sequenceReady) {
			if (Input.GetButtonDown (buttonA)) {
				sequence [placedItems] = "A";
				placedItems++;
			} else if (Input.GetButtonDown (buttonB)) {
				sequence [placedItems] = "B";
				placedItems++;
			} else if (Input.GetButtonDown (buttonX)) {
				sequence [placedItems] = "X";
				placedItems++;
			} else if (Input.GetButtonDown (buttonY)) {
				sequence [placedItems] = "Y";
				placedItems++;
			}  
			if (placedItems == sequenceLength) {
				sequenceReady = true;
			}
		}
	}

	public void Init(){
		sequenceLength = FindObjectOfType<BathroomNew> ().sequenceLength;
		sequence = new string[sequenceLength];
	}

	public bool IsReady(){
		return sequenceReady;
	}

	public string[] GetSequence(){
		string[] result = sequence;
		placedItems = 0;
		sequenceReady = false;
		return result;
	}
}
