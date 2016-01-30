using UnityEngine;
using System.Collections;

public class Ironing : MonoBehaviour {

	public Transform leftEnd;
	public Transform rightEnd;
	public Transform correctPosition;
	public Transform cursor;
	string playerButton = null;
	public float cursorSpeed = 3f;
	public GameObject button;
	int direction = -1;
	float offset = 0f;
	float interval = .3f;
	float elapsedTime = 0f;
	bool countTime = false;
	bool correct = false;
	GameObject activePlayer;

	// Use this for initialization
	void Start () {
		float cursorWidth = cursor.GetComponent<Renderer> ().bounds.size.x;
		offset = cursorWidth / 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerButton != null) {
			if (cursor.position.x - offset <= leftEnd.position.x) {
				direction = 1;
			}
			if (cursor.position.x + offset >= rightEnd.position.x) {
				direction = -1;
			}
			cursor.Translate (new Vector3 (cursorSpeed, 0f, 0f) * Time.deltaTime * direction);
			if (Input.GetButtonDown (playerButton)) {
				if (correct) {
					button.GetComponent<ShowButton> ().ShowGreen ();
				} else {
					button.GetComponent<ShowButton> ().ShowRed ();
				}
				countTime = true;
				elapsedTime = 0f;
			}
			if (countTime) {
				if (elapsedTime > interval) {
					button.GetComponent<ShowButton> ().ShowNormal ();
					elapsedTime = 0f;
					countTime = false;
				} else {
					elapsedTime += Time.deltaTime;
				}
			}
		}

	}

	public void SetActivePlayer(GameObject player){
		activePlayer = player;
		playerButton = activePlayer.GetComponent<IroningController> ().GetButtonA ();
	}

	public void DisableInput(){
		playerButton = null;
	}

	void OnTriggerEnter2D(Collider2D coll){
		correct = true;
	}


	void OnTriggerExit2D(Collider2D coll){
		correct = false;
	}
}
