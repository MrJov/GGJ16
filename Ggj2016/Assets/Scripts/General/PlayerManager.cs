using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public struct PlayerDisposition
	{
		public GameObject player;
		public GameObject gameZone;
		public bool arrived;
	}

	public GameObject[] players = new GameObject[4];
	public GameObject[] gameZones = new GameObject[4];
	PlayerDisposition[] disposition = new PlayerDisposition[4];
	float speed = 2f;

	public float levelTime = 5f;
	float elapsedTime = 0f;

	bool movePlayers = false;

	// Use this for initialization
	void Start () {
		RandomizeArray (gameZones);
		AssignPlayers ();
	}
	
	// Update is called once per frame
	void Update () {
		if (movePlayers) {
			MovePlayers ();
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
		}
	}

	void RandomizeArray(GameObject[] array){
		for (int i = 0; i < array.Length; i++) {
			GameObject tmp = array [i];
			int r = Random.Range (i, array.Length);
			array [i] = array [r];
			array [r] = tmp;
		}
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
	}

	void RotateCross(){
	}
}
