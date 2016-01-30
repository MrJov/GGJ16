using UnityEngine;
using System.Collections;

public class MovementSpot : MonoBehaviour {
	/*
	[System.Serializable]
	public struct MovementSpotCouple
	{
		public GameObject destination;
		public GameObject nextSpot;
	}
*/
	public bool crossRoad = false;
	bool check = false;
	public GameObject[] nearSpots;
	public GameObject nextCrossroad;
	MapPlayer player;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Go(MapPlayer p){
		player = p;
		if (!gameObject.name.Equals (player.GetDestination ().name)) {
			bool going = false;
			if (crossRoad) {
				for (int i = 0; i < nearSpots.Length; i++) {
					if (nearSpots [i].name.Equals (player.GetDestination ().name)) {
						player.Move (nearSpots [i]);
						going = true;
						break;
					}
				}
				if (!going) {
					player.Move (nextCrossroad);
				}	
			} else {
				player.Move (nextCrossroad);
			}
		}

	}

	/*
	void OnTriggerEnter2D(Collider2D coll){
		Go(coll.gameObject.GetComponent<MapPlayer> ());
	}
	*/

	void OnTriggerStay2D(Collider2D coll){
		Go(coll.gameObject.GetComponent<MapPlayer> ());
	}

}
