using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RewardManager : MonoBehaviour {

	public Image progressBar;
	public float step = 20f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Increment(){
		progressBar.rectTransform.sizeDelta += new Vector2(step, 0f);
	}
}
