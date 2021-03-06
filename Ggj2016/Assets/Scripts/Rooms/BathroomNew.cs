﻿using UnityEngine;
using System.Collections;

public class BathroomNew : MonoBehaviour {

	public float interval = 5f;
	float elapsedTime = 0f;
	float resultTimer = .3f;
	float elapsedResult = 0f;
	bool showResult = false;
	public Transform spawnPoint;
	float offset = 1f;
	public GameObject [] buttonsToSpawn;
	GameObject[] sequence;
	public int sequenceLength = 5;
	bool active = false;

	GameObject activePlayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			if (showResult) {
				if (elapsedResult > resultTimer) {
					elapsedResult = 0f;
					EraseSequence ();
					PrepareSequence ();
					showResult = false;
				} else {
					elapsedResult += Time.deltaTime;
				}
			} else {
				if (elapsedTime > interval) {
					EraseSequence ();
					PrepareSequence ();
				} else {
					if (activePlayer.GetComponent<BathroomControl> ().IsReady ()) {
						string[] sequenceInput = activePlayer.GetComponent<BathroomControl> ().GetSequence ();
						bool correct = true;
						for (int i = 0; i < sequenceLength; i++) {
							if ((sequenceInput [i].Equals ("A") && !sequence [i].GetComponent<ShowButton> ().GetLetter ().Equals ("A")) ||
							   (sequenceInput [i].Equals ("B") && !sequence [i].GetComponent<ShowButton> ().GetLetter ().Equals ("B")) ||
							   (sequenceInput [i].Equals ("X") && !sequence [i].GetComponent<ShowButton> ().GetLetter ().Equals ("X")) ||
							   (sequenceInput [i].Equals ("Y") && !sequence [i].GetComponent<ShowButton> ().GetLetter ().Equals ("Y"))) {
								correct = false;
							}
						}
						if (correct) {
							for (int i = 0; i < sequenceLength; i++) {
								sequence [i].GetComponent<ShowButton> ().ShowGreen ();
							}
							FindObjectOfType<RewardManager> ().Increment ();
						} else {

							for (int i = 0; i < sequenceLength; i++) {
								sequence [i].GetComponent<ShowButton> ().ShowRed ();
							}
						}
						showResult = true;
					}
					elapsedTime += Time.deltaTime;
				}

			}
		}
	}

	void PrepareSequence(){
		sequence = new GameObject[sequenceLength];
		for (int i = 0; i < sequenceLength; i++) {
			GameObject go = Instantiate<GameObject> (buttonsToSpawn [Random.Range (0, buttonsToSpawn.Length)]) as GameObject;
			go.transform.position = spawnPoint.position + new Vector3(offset, 0f, 0f)*i;
			go.transform.parent = transform;
			sequence [i] = go;
			sequence [i].GetComponent<ShowButton> ().ShowNormal ();
		}
		elapsedTime = 0f;
	}

	void EraseSequence(){
		for (int i = 0; i < sequenceLength; i++) {
			Destroy (sequence [i]);
		}
	}

	public void SetActivePlayer(GameObject player){
		activePlayer = player;
		active = true;
		PrepareSequence ();
	}

	public void Reset(){
		active = false;
	}
}
