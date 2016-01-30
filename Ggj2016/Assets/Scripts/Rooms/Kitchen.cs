using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Kitchen : MonoBehaviour {

	public float actionTime = 3f;
	public Text actionToDo;
	public Text actionPerformed;
	public Image timeBar;
	public GameObject activePlayer;

	Vector2 fullBarSize;
	float elapsedTime = 0f;
	string action;

	// Use this for initialization
	void Start () {
		action = GenerateAction (Random.Range (0, 4));
		actionToDo.text = action;
		fullBarSize = timeBar.rectTransform.sizeDelta;
	}
	
	// Update is called once per frame
	void Update () {
		if (elapsedTime > actionTime) {
			action = GenerateAction (Random.Range (0, 4));
			actionToDo.text = action;
			elapsedTime = 0f;
		} else {
			elapsedTime += Time.deltaTime;
		}
		string actionPerf = activePlayer.GetComponent<KitchenController> ().GetPlayerAction ();
		actionPerformed.text = actionPerf;
		float percTime = elapsedTime / actionTime;
		timeBar.rectTransform.sizeDelta = new Vector2 ((1 - percTime) * fullBarSize.x, fullBarSize.y);
	}

	string GenerateAction(int index){
		switch (index) {
		case 0:
			return "Up and down";
			break;
		case 1:
			return "Left and right";
			break;
		case 2:
			return "Clockwise";
			break;
		case 3:
			return "Counterclockwise";
			break;
		default:
			return "WUT??";
			break;
		}
	}
}
