using UnityEngine;
using System.Collections;

public class Ironing : MonoBehaviour {

	public Transform leftEnd;
	public Transform rightEnd;
	public Transform correctPosition;
	public Transform cursor;
	public float cursorSpeed = 3f;
	int direction = -1;

	// Use this for initialization
	void Start () {
		float cursorWidht = cursor.GetComponent<Renderer> ().bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (cursor.position.x <= leftEnd.position.x) {
			direction = 1;
		}
		if (cursor.position.x >= rightEnd.position.x) {
			direction = -1;
		}
		cursor.Translate (new Vector3 (cursorSpeed, 0f, 0f) * Time.deltaTime * direction);


	}
}
