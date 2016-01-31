using UnityEngine;
using System.Collections;

public class SlidingButton : MonoBehaviour {

	int direction = 0;
	float speed = 0f;
	bool go = false;

	public string buttonLetter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (go) {
			transform.Translate (new Vector3 (speed, 0f, 0f) * Time.deltaTime*direction);
		}
	}

	public void Go(int dir, float spd){
		direction = dir;
		speed = spd;
		go = true;
	}

	public string GetLetter(){
		return buttonLetter;
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.CompareTag ("DestroyPoint")) {
			Destroy (gameObject);
		}
	}
}
