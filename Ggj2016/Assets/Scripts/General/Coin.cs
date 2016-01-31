using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	float speed = 8f;
	GameObject destination;
	bool move = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (move) {
			transform.position = Vector3.MoveTowards (transform.position, destination.transform.position, speed * Time.deltaTime); 
			if (transform.position == destination.transform.position) {
				Destroy (gameObject);
			}
		}
	}

	public void Move(GameObject dest, float spd){
		speed = spd;
		destination = dest;
		move = true;
	}
}
