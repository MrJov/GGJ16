using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public struct PlayerDisposition
	{
		public GameObject player;
		public GameObject gameZone;
		public bool arrived;
	}

	public GameObject[] players = new GameObject[4];
	public GameObject[] gameZones = new GameObject[4];
	PlayerDisposition[] disposition = new PlayerDisposition[4];

	bool began = false;
	public float levelTime = 5f;
	float elapsedTime = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(began){
			if (elapsedTime > levelTime) {
				began = false;
				EndLevel ();
			} else {
				elapsedTime += Time.deltaTime;
			}
		}
	}




	public void BeginLevel(GameObject[] orderedZones){
		for (int j = 0; j < orderedZones.Length; j++) {
			for (int h = j; h < gameZones.Length; h++) {
				if (gameZones [h].name.Equals (orderedZones [j].name)) {
					GameObject tmp = gameZones [j];
					gameZones [j] = gameZones [h];
					gameZones [h] = tmp;
				}
			}
		}
		for(int k = 0; k < disposition.Length; k++){
			disposition [k].gameZone = gameZones [k];
			disposition [k].player = players [k];
		}
		for (int i = 0; i < disposition.Length; i++) {
			disposition [i].player.transform.position = disposition [i].gameZone.transform.GetChild (0).position;
		}
		InitZones ();
	}

	void EndLevel(){
		elapsedTime = 0f;

		//TODO: Implement rewards/malus

		ResetZones ();
		FindObjectOfType<MapManager> ().Show ();
	}

	void InitZones(){
		for (int i = 0; i < disposition.Length; i++)
		{
			if (disposition [i].gameZone.gameObject.name.Equals ("GarbageZone")) {
				disposition [i].gameZone.gameObject.GetComponent<GarbageRoom> ().enabled = true;
				disposition [i].player.GetComponent<InputButtonTrash> ().enabled = true;
				disposition [i].player.GetComponent<InputButtonTrash> ().Enable ();
			}
			if (disposition [i].gameZone.gameObject.name.Equals ("BathroomZone")) {
				disposition [i].gameZone.gameObject.GetComponent<BathRoom> ().enabled = true;
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
		began = true;
	}

	void ResetZones(){
		for (int i = 0; i < disposition.Length; i++)
		{
			if (disposition[i].gameZone.gameObject.name.Equals("GarbageZone"))
			{
				disposition [i].player.GetComponent<InputButtonTrash> ().Disable ();
				disposition [i].player.GetComponent<InputButtonTrash> ().enabled = false;
				disposition[i].gameZone.gameObject.GetComponent<GarbageRoom>().enabled = false;
			}
			if (disposition [i].gameZone.gameObject.name.Equals ("BathroomZone")) {
				disposition [i].player.GetComponent<InputButtonToilet> ().Disable ();
				disposition [i].player.GetComponent<InputButtonToilet> ().enabled = false;
				disposition [i].gameZone.gameObject.GetComponent<BathRoom> ().enabled = false;
				disposition[i].gameZone.gameObject.GetComponent<BathRoom>().Delete();
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
	}

}
