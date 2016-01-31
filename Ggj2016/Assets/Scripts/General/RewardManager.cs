﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RewardManager : MonoBehaviour {

	public Image progressBar;
	float step;
	float[] shares;
	public float numShares = 10;
	int actualShare = 0;
	public float neededPoints;
	float maxLength;

	// Use this for initialization
	void Start () {
		maxLength = Screen.width;
		shares = new float[(int)numShares];
		float index = 1 / numShares;
		for (int i = 0; i < numShares; i++) {
			shares [i] = index * (i+1);
		}
		step = maxLength * index / neededPoints;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Increment(){
		progressBar.rectTransform.sizeDelta += new Vector2(step, 0f);
		Debug.Log (step);
		Debug.Log (progressBar.rectTransform.sizeDelta.x);
		if (progressBar.rectTransform.sizeDelta.x >= shares [actualShare] * maxLength) {
			Debug.Log ("+1 COIN");
			if (actualShare != numShares - 1) {
				actualShare++;
			}
		}
	}

	public void ResetReward(){
		Debug.Log ("RESET");
		actualShare = 0;
		progressBar.rectTransform.sizeDelta = new Vector2(0f, progressBar.rectTransform.sizeDelta.y);
	}
}
