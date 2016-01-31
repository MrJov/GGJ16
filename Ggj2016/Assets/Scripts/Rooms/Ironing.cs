using UnityEngine;
using System.Collections;

public class Ironing : MonoBehaviour {

	public Transform leftIron;
	public Transform rightIron;
	public Transform iron;
	float ironSpeed;
	public Transform leftEnd;
	public Transform rightEnd;
	public Transform correctPosition;
	public Transform cursor;
	public GameObject ironBar;
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
		ShowElements ();
		float ironDistance = rightIron.position.x - leftIron.position.x;
		float cursorDistance = rightEnd.position.x - leftEnd.position.x;
		ironSpeed = ironDistance * cursorSpeed / cursorDistance;
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
			iron.Translate (new Vector3 (ironSpeed, 0f, 0f) * Time.deltaTime * direction);
			if (Input.GetButtonDown (playerButton)) {
				if (correct) {
					button.GetComponent<ShowButton> ().ShowGreen ();
					FindObjectOfType<RewardManager> ().Increment ();
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
		ShowElements ();
	}

	public void Disable(){
		playerButton = null;
		ironBar.gameObject.SetActive (false);
		cursor.gameObject.SetActive (false);
		button.gameObject.SetActive (false);
	}

	void ShowElements(){
		ironBar.gameObject.SetActive (true);
		cursor.gameObject.SetActive (true);
		button.gameObject.SetActive (true);
	}

	void OnTriggerEnter2D(Collider2D coll){
		correct = true;
	}


	void OnTriggerExit2D(Collider2D coll){
		correct = false;
	}
}
