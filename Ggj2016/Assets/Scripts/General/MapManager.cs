using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {

	public struct PlayerDisposition
	{
		public GameObject player;
		public GameObject gameZone;
		public bool arrived;
	}

	public GameObject[] players = new GameObject[4];
	public GameObject[] gameZones = new GameObject[4];
	PlayerDisposition[] disposition = new PlayerDisposition[4];

	bool movePlayers = false;
	bool playerInMovement = false;
	float speed = 5f;

	public float fadeTime = 2f;
	bool fadeOut = false;
	bool fadeIn = false;
	float elapsedFade = 0f;

	public GameObject GUI;

	bool addCoins = false;
	int numCoins = 0;
	int coinsToAdd = 0;
	int addedCoins = 0;
	public GameObject moneyBox;
	public GameObject coinsSpawnPoint;
	public GameObject coin;
	public float coinInterval;
	float elapsedCoins = 0f;
	public float coinsSpeed = 8f;

	public GameObject check;
	public float timeCheck;
	float elapsedCheck;
	bool showingCheck = false;
	bool checkOn = false;

	// Use this for initialization
	void Start () {
		AssignPlayers ();
	}
	
	// Update is called once per frame
	void Update () {
		if (checkOn && !fadeIn) {
			ShowCheck ();
		}
		if (movePlayers && !showingCheck) {
			MovePlayers ();
		}
		if (addCoins && !showingCheck) {
			MoveCoins ();
		}
		if (fadeOut && !addCoins && !showingCheck) {
			Fade (false);
		}
		if (fadeIn) {
			Fade (true);
		}
	}

	void MoveCoins(){
		if (addedCoins < coinsToAdd) {
			if (elapsedCoins >= coinInterval) {
				GameObject go = Instantiate<GameObject> (coin) as GameObject;
				go.transform.position = coinsSpawnPoint.transform.position;
				go.GetComponent<Coin> ().Move (moneyBox, coinsSpeed);
				addedCoins++;
				numCoins++;
				elapsedCoins = 0f;
			} else {
				elapsedCoins += Time.deltaTime;
			}
		} else {
			addCoins = false;
			addedCoins = 0;
		}
	}

	void AssignPlayers (){
		for (int i = 0; i < disposition.Length; i++) {
			disposition [i].player = players [i];
			disposition [i].gameZone = gameZones [i];
			disposition [i].arrived = false;
		}
		movePlayers = true;
	}

	void MovePlayers(){
		float step = speed * Time.deltaTime;
		for (int i = 0; i < disposition.Length; i++) {
			disposition [i].player.transform.position = Vector3.MoveTowards (disposition [i].player.transform.position, 
																			disposition [i].gameZone.transform.position,
																			step);
			if (disposition [i].player.transform.position == disposition [i].gameZone.transform.position) {
				disposition [i].arrived = true;
			}
		}
		if (disposition [0].arrived && disposition [1].arrived && disposition [2].arrived && disposition [3].arrived) {
			movePlayers = false;
			fadeOut = true;

			for (int i = 0; i < players.Length; i++) {
				players [i].GetComponent<Renderer> ().enabled = false;
				moneyBox.GetComponent<Renderer> ().enabled = false;
			}
		}
	}

	void Fade(bool appearing){
		float transparency = 0f;
		elapsedFade += Time.deltaTime;
		float percTime = elapsedFade / fadeTime;
		if (appearing) {
			Camera.main.orthographicSize = Mathf.Lerp (5.2f, 8f, percTime);
			transparency = Mathf.Lerp (0f, 1f, percTime);
		} else {
			Camera.main.orthographicSize = Mathf.Lerp (8f, 5.2f, percTime);
			transparency = Mathf.Lerp (1f, 0f, percTime);
		}
		Color tmp = GetComponent<Renderer> ().material.color;
		tmp.a = transparency;
		GetComponent<Renderer> ().material.color = tmp;
		if (elapsedFade > fadeTime) {
			if (appearing) {
				for (int i = 0; i < players.Length; i++) {
					players [i].GetComponent<Renderer> ().enabled = true;
					moneyBox.GetComponent<Renderer> ().enabled = true;
				}
				fadeIn = false;
				addCoins = true;
				RotatePositions ();
				AssignPlayers ();
			} else {
				GUI.SetActive (true);
				fadeOut = false;
				FindObjectOfType<LevelManager> ().BeginLevel (gameZones);
			}
			elapsedFade = 0f;
		}
	}

	public void Show(){
		fadeIn = true;
		GUI.SetActive (false);
	}

	void RotatePositions(){
		int mode = Random.Range (0, 3);
		switch (mode) {
		case 0:
			RotateLeft ();
			break;
		case 1:
			RotateRight ();
			break;
		case 2:
			RotateCross ();
			break;
		default:
			break;
		}
	}

	void RotateLeft(){
		for (int i = 0; i < gameZones.Length-1; i++) {
			GameObject tmp = gameZones [i];
			gameZones [i] = gameZones [i + 1];
			gameZones [i + 1] = tmp;
		}
	}

	void RotateRight(){
		for (int i = gameZones.Length-1; i > 0; i--) {
			GameObject tmp = gameZones [i];
			gameZones [i] = gameZones [i - 1];
			gameZones [i - 1] = tmp;
		}
	}

	void RotateCross(){
		GameObject tmp = gameZones [0];
		gameZones [0] = gameZones [2];
		gameZones [2] = tmp;
		tmp = gameZones [1];
		gameZones [1] = gameZones [3];
		gameZones [3] = tmp;
	}

	public void AddCoins(int num){
		coinsToAdd = num;
	}

	void ShowCheck(){
		if (!showingCheck) {
			showingCheck = true;
			check.SetActive (true);
		} else if (elapsedCheck > timeCheck) {
			showingCheck = false;
			check.SetActive (false);
			checkOn = false;
			elapsedCheck = 0f;
		} else {
			elapsedCheck += Time.deltaTime;
		}
	}

	public void CheckOn(){
		checkOn = true;
	}
}
