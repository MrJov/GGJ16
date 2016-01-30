using UnityEngine;
using System.Collections;

public class MapPlayer : MonoBehaviour {

	public GameObject finalDestination;
	public GameObject tempDestination;
	float speed = 5f;
	bool go = false;

	void Update(){
		if (go) {
			if (transform.position != finalDestination.transform.position) {
				transform.position = Vector3.MoveTowards (transform.position, tempDestination.transform.position, speed * Time.deltaTime);
			} else {
				go = false;
			}
		}
	}

	public void Move(GameObject tmp){
		tempDestination = tmp;
	}

	public GameObject GetDestination(){
		return finalDestination;
	}

	public void SetDestination(GameObject tmp){
		finalDestination = tmp;
		go = true;
	}

}
