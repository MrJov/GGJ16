﻿using UnityEngine;
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
	public float speed = 4f;

	public float levelTime = 5f;
	float elapsedTime = 0f;

	bool movePlayers = false;

	// Use this for initialization
	void Start () {
		//RandomizeArray (gameZones);
		for (int i = 0; i < disposition.Length; i++) {
			disposition [i].player = players [i];
			disposition [i].gameZone = gameZones [i];
			disposition [i].arrived = false;
		}
		AssignPlayers ();
	}
	
	// Update is called once per frame
	void Update () {
		if (movePlayers) {
			MovePlayers ();
		} else {
			if (elapsedTime > levelTime) {
				RotatePositions ();
				AssignPlayers ();
				elapsedTime = 0;
			} else {
				elapsedTime += Time.deltaTime;
			}
		}
	}

	void AssignPlayers (){

		for (int i = 0; i < disposition.Length; i++)
		{
			if (disposition[i].gameZone.gameObject.name.Equals("GarbageZone"))
			{
				disposition [i].player.GetComponent<InputButtonTrash> ().Disable ();
                disposition[i].gameZone.gameObject.GetComponent<GarbageRoom>().Disabled();
                disposition [i].player.GetComponent<InputButtonTrash> ().enabled = false;
                disposition[i].gameZone.gameObject.GetComponent<GarbageRoom>().enabled = false;
            
			}
			if (disposition [i].gameZone.gameObject.name.Equals ("BathroomZone"))
            {
				disposition [i].player.GetComponent<InputButtonToilet> ().Disable ();
                disposition[i].gameZone.gameObject.GetComponent<BathRoom>().Disable();
                disposition [i].player.GetComponent<InputButtonToilet> ().enabled = false;
				disposition [i].gameZone.gameObject.GetComponent<BathRoom> ().enabled = false;
                
            }

			if (disposition[i].gameZone.gameObject.name.Equals("KitchenZone")){
				disposition [i].gameZone.gameObject.GetComponent<Kitchen> ().Reset ();
				disposition[i].gameZone.gameObject.GetComponent<Kitchen>().enabled = false;
				disposition [i].player.GetComponent<KitchenController> ().enabled = false;
			}

			if (disposition[i].gameZone.gameObject.name.Equals("IroningZone")){
				disposition [i].gameZone.gameObject.GetComponent<Ironing> ().Disable ();
				disposition[i].gameZone.gameObject.GetComponent<Ironing>().enabled = false;
				disposition [i].player.GetComponent<IroningController> ().enabled = false;
			}
		}

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
																			disposition [i].gameZone.transform.GetChild(0).position,
																			step);
			if (disposition [i].player.transform.position == disposition [i].gameZone.transform.GetChild(0).position) {
				disposition [i].arrived = true;
			}
		}
		if (disposition [0].arrived && disposition [1].arrived && disposition [2].arrived && disposition [3].arrived)
        {
			movePlayers = false;

            for (int i = 0; i < disposition.Length; i++)
            {
				if (disposition [i].gameZone.gameObject.name.Equals ("GarbageZone"))
                {
					disposition [i].gameZone.gameObject.GetComponent<GarbageRoom> ().enabled = true;
                    disposition[i].gameZone.gameObject.GetComponent<GarbageRoom>().Enabled(disposition[i].player);
                    disposition [i].player.GetComponent<InputButtonTrash> ().enabled = true;
                    disposition [i].player.GetComponent<InputButtonTrash> ().Enable ();
                    
                }
				if (disposition [i].gameZone.gameObject.name.Equals ("BathroomZone")) {
					disposition [i].gameZone.gameObject.GetComponent<BathRoom> ().enabled = true;
                    disposition[i].gameZone.gameObject.GetComponent<BathRoom>().Enable(disposition[i].player);
                    disposition [i].player.GetComponent<InputButtonToilet> ().enabled = true;
					disposition [i].player.GetComponent<InputButtonToilet> ().Enable ();
				}
				if (disposition[i].gameZone.gameObject.name.Equals("KitchenZone")){
					disposition[i].gameZone.gameObject.GetComponent<Kitchen>().enabled = true;
					disposition [i].player.GetComponent<KitchenController> ().enabled = true;
					disposition[i].gameZone.gameObject.GetComponent<Kitchen>().SetActivePlayer(disposition[i].player);
				}

				if (disposition[i].gameZone.gameObject.name.Equals("IroningZone")){
					disposition[i].gameZone.gameObject.GetComponent<Ironing>().enabled = true;
					disposition [i].player.GetComponent<IroningController> ().enabled = true;
					disposition[i].gameZone.gameObject.GetComponent<Ironing>().SetActivePlayer(disposition[i].player);
				}
            }
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
		Debug.Log (mode);
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
