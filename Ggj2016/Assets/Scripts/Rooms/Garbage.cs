using UnityEngine;
using System.Collections;

public class Garbage : MonoBehaviour {

	public float interval = 3f;
	float elapsedTime = 4f;
	public GameObject[] buttonsToSpawn;
	string[] playerButtons;
	public float speed;
	public Transform spawnPoint;
	public Transform pressPoint;
	bool valid = false;
	GameObject currentButton;
	bool active = false;
	bool hit = false;
	int itemToSpawn;
	GameObject[] buttons;
	int index = 0;

	GameObject activePlayer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			if (elapsedTime > interval) {
				buttons [index].GetComponent<ShowButton> ().ShowNormal ();
				buttons [index].GetComponent<SlidingButton> ().Go (-1, speed);
				index++;
				elapsedTime = 0f;
			} else {
				elapsedTime += Time.deltaTime;
			}
			if (valid) {
				if (Input.GetButtonDown (playerButtons [0]) && currentButton.GetComponent<SlidingButton> ().buttonLetter.Equals ("A")) {
					currentButton.GetComponent<ShowButton> ().ShowGreen ();
					hit = true;
					FindObjectOfType<RewardManager> ().Increment ();
				} else if (Input.GetButtonDown (playerButtons [1]) && currentButton.GetComponent<SlidingButton> ().buttonLetter.Equals ("B")) {
					currentButton.GetComponent<ShowButton> ().ShowGreen ();
					hit = true;
					FindObjectOfType<RewardManager> ().Increment ();
				} else if (Input.GetButtonDown (playerButtons [2]) && currentButton.GetComponent<SlidingButton> ().buttonLetter.Equals ("X")) {
					currentButton.GetComponent<ShowButton> ().ShowGreen ();
					hit = true;
					FindObjectOfType<RewardManager> ().Increment ();
				} else if (Input.GetButtonDown (playerButtons [3]) && currentButton.GetComponent<SlidingButton> ().buttonLetter.Equals ("Y")) {
					currentButton.GetComponent<ShowButton> ().ShowGreen ();
					hit = true;
					FindObjectOfType<RewardManager> ().Increment ();
				}
				
			}
		}
	}

	public void SetActivePlayer(GameObject player, float totalTime){
		activePlayer = player;
		playerButtons = activePlayer.GetComponent<GarbageController> ().GetButtons ();
		itemToSpawn = Mathf.RoundToInt (totalTime / interval) + 2;
		buttons = new GameObject[itemToSpawn];
		for (int i = 0; i < buttons.Length; i++) {
			GameObject go = Instantiate<GameObject> (buttonsToSpawn [Random.Range (0, buttonsToSpawn.Length)]) as GameObject;
			go.transform.position = spawnPoint.position;
			go.transform.parent = transform;
			buttons [i] = go;
			buttons [i].GetComponent<ShowButton> ().HideAll ();
		}
		elapsedTime = interval;
		active = true;
	}

	public void Reset(){
		active = false;
		for (int i = index; i < buttons.Length; i++) {
			Destroy (buttons [i]);
		}
		index = 0;
		currentButton = null;
	}

	void OnTriggerEnter2D(Collider2D coll){
		valid = true;
		hit = false;
		currentButton = coll.gameObject;
	}

	void OnTriggerExit2D(Collider2D coll){
		valid = false;
		if (!hit) {
			if (currentButton != null && currentButton.GetComponent<ShowButton> () != null) {
				currentButton.GetComponent<ShowButton> ().ShowRed ();
			}
		}
	}
}
