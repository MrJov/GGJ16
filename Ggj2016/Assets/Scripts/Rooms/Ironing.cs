using UnityEngine;
using System.Collections;

public class Ironing : MonoBehaviour {

	public Transform leftEnd;
	public Transform rightEnd;
	public Transform correctPosition;
	public Transform cursor;
	public string playerButton;
	public float cursorSpeed = 3f;
	public GameObject result;
	int direction = -1;
	float offset = 0f;
	bool correct = false;

	// Use this for initialization
	void Start () {
		float cursorWidth = cursor.GetComponent<Renderer> ().bounds.size.x;
		offset = cursorWidth / 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (cursor.position.x - offset <= leftEnd.position.x) {
			result.GetComponent<Renderer> ().material.color = Color.white;
			direction = 1;
		}
		if (cursor.position.x + offset >= rightEnd.position.x) {
			result.GetComponent<Renderer> ().material.color = Color.white;
			direction = -1;
		}
		cursor.Translate (new Vector3 (cursorSpeed, 0f, 0f) * Time.deltaTime * direction);
		if (Input.GetButtonDown (playerButton)) {
			if (correct) {
				result.GetComponent<Renderer> ().material.color = Color.green;
			} else {
				result.GetComponent<Renderer> ().material.color = Color.red;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		correct = true;
	}


	void OnTriggerExit2D(Collider2D coll){
		correct = false;
	}
}
