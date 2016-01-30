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


	// Use this for initialization
	void Start () {
		AssignPlayers ();
	}
	
	// Update is called once per frame
	void Update () {
		if (movePlayers) {
			MovePlayers ();
		}
		if (fadeOut) {
			Fade (false);
		}
		if (fadeIn) {
			Fade (true);
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
		}
	}

	void Fade(bool appearing){
		float transparency = 0f;
		elapsedFade += Time.deltaTime;
		float percTime = elapsedFade / fadeTime;
		if (appearing) {
			Camera.main.orthographicSize = Mathf.Lerp (5f, 8f, percTime);
			transparency = Mathf.Lerp (0f, 1f, percTime);
		} else {
			Camera.main.orthographicSize = Mathf.Lerp (8f, 5f, percTime);
			transparency = Mathf.Lerp (1f, 0f, percTime);
		}
		Color tmp = GetComponent<Renderer> ().material.color;
		tmp.a = transparency;
		GetComponent<Renderer> ().material.color = tmp;
		if (elapsedFade > fadeTime) {
			if (appearing) {
				for (int i = 0; i < players.Length; i++) {
					players [i].GetComponent<Renderer> ().enabled = true;
				}
				fadeIn = false;
				RotatePositions ();
				AssignPlayers ();
			} else {
				for (int i = 0; i < players.Length; i++) {
					players [i].GetComponent<Renderer> ().enabled = false;
				}
				fadeOut = false;
				FindObjectOfType<LevelManager> ().BeginLevel (gameZones);
			}
			elapsedFade = 0f;
		}
	}

	public void Show(){
		fadeIn = true;
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
}
