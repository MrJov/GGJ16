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

	int oldInput = -1;

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
		int inputInt;
		if (input == DPadPosition (0)) {
			inputInt = 0;
		} else if (input == DPadPosition(1)) {
			inputInt = 1;
		} else if (input == DPadPosition(2)) {
			inputInt = 2;
		} else if (input == DPadPosition(3)) {
			inputInt = 3;
		} else if (input == DPadPosition(4)) {
			inputInt = 4;
		} else if (input == DPadPosition(5)) {
			inputInt = 5;
		} else if (input == DPadPosition(6)) {
			inputInt = 6;
		} else if (input == DPadPosition(7)) {
			inputInt = 7;
		} else {
			inputInt = -5;
		}
		if (inputInt == oldInput + 1) {
			upDown = false;
			clockwise = true;
			counterClockwise = false;
			leftRight = false;
		} else if (inputInt == oldInput - 1) {
				upDown = false;
			clockwise = false;
			counterClockwise = true;
				leftRight = false;
		} else if (((inputInt == 7 || inputInt == 0 || inputInt == 1) && (oldInput == 3 || oldInput == 4 || oldInput == 5)) || 
					((inputInt == 3 || inputInt == 4 || inputInt == 5) && (oldInput == 7 || oldInput == 0 || oldInput == 1))){
			upDown = true;
			clockwise = false;
			counterClockwise = false;
			leftRight = false;
		} else if (((inputInt == 7 || inputInt == 6 || inputInt == 5) && (oldInput == 1 || oldInput == 2 || oldInput == 3)) || 
			((inputInt == 1 || inputInt == 2 || inputInt == 3) && (oldInput == 5 || oldInput == 6 || oldInput == 7))){
			upDown = false;
			clockwise = false;
			counterClockwise = false;
			leftRight = true;
		}
		elapsedTime = 0f;
		oldInput = inputInt;
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
