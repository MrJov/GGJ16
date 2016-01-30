using UnityEngine;
using System.Collections;

public class KitchenController : MonoBehaviour {

	public string dPadXAxis;
	public string dPadYAxis;

	public bool clockwise = false;
	public bool counterClockwise = false;
	public bool leftRight = false;
	public bool upDown = false;

	public float maxInterval = .3f;
	float elapsedTime = 0f;

	Vector2 oldInput = Vector2.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 input = new Vector2 (Input.GetAxisRaw (dPadXAxis), Input.GetAxisRaw (dPadYAxis));

		if (input != Vector2.zero) {
			CheckMovement (input);
			Debug.Log (input.x + ", " + input.y);
		}
		if (elapsedTime > maxInterval) {
			leftRight = false;
			clockwise = false;
			counterClockwise = false;
			upDown = false;
		} else {
			elapsedTime += Time.deltaTime;
		}
	}

	void CheckMovement(Vector2 input){
		if ((input.y < 0f && oldInput.y > 0f) || (input.y > 0f && oldInput.y < 0f)) {
			upDown = true;
			clockwise = false;
			counterClockwise = false;
			leftRight = false;
		} else if ((input.x < 0f && oldInput.x > 0f) || (input.x > 0f && oldInput.x < 0f)) {
			leftRight = true;
			clockwise = false;
			counterClockwise = false;
			upDown = false;
		} else if ((input == DPadPosition(0) && oldInput == DPadPosition(7)) || (input == DPadPosition(1) && oldInput == DPadPosition(0)) ||
			(input == DPadPosition(2) && oldInput == DPadPosition(1)) || (input == DPadPosition(3) && oldInput == DPadPosition(2)) ||
			(input == DPadPosition(4) && oldInput == DPadPosition(3)) || (input == DPadPosition(5) && oldInput == DPadPosition(4)) || 
			(input == DPadPosition(6) && oldInput == DPadPosition(5)) || (input == DPadPosition(7) && oldInput == DPadPosition(6))) {
			leftRight = false;
			clockwise = true;
			counterClockwise = false;
			upDown = false;
		} else if ((input == DPadPosition(0) && oldInput == DPadPosition(1)) || (input == DPadPosition(1) && oldInput == DPadPosition(2)) ||
			(input == DPadPosition(2) && oldInput == DPadPosition(3)) || (input == DPadPosition(3) && oldInput == DPadPosition(4)) ||
			(input == DPadPosition(4) && oldInput == DPadPosition(5)) || (input == DPadPosition(5) && oldInput == DPadPosition(6)) || 
			(input == DPadPosition(6) && oldInput == DPadPosition(7)) || (input == DPadPosition(7) && oldInput == DPadPosition(0))) {
			leftRight = false;
			clockwise = false;
			counterClockwise = true;
			upDown = false;
		}
		elapsedTime = 0f;
		oldInput = input;
	}

	Vector2 DPadPosition(int pos){
		Vector2[] positions = new Vector2[] {
			Vector2.up,
			new Vector2 (0.7070774f, 0.7070774f),
			Vector2.right,
			new Vector2 (0.7070774f, -0.7070774f),
			Vector2.down,
			new Vector2 (-0.7070774f, -0.7070774f),
			Vector2.left,
			new Vector2 (-0.7070774f, 0.7070774f)
		};
		return positions [pos];
	}

	public string GetPlayerAction(){
		if (clockwise) {
			return "CLOCKWISE";
		} else if (counterClockwise) {
			return "COUNTERCLOCKWISE";
		} else if (upDown) {
			return "UP AND DOWN";
		} else if (leftRight) {
			return "LEFT AND RIGHT";
		} else {
			return "NOTHING";
		}
	}

}
