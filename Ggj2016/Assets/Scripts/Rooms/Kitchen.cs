using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Kitchen : MonoBehaviour {

	public float actionTime = 3f;
	public Text actionToDo;
	public Text actionPerformed;
	public Text result;
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
		if (action.Equals (actionPerf)) {
			result.text = "OK";
		} else {
			result.text = "NO";
		}
		float percTime = elapsedTime / actionTime;
		timeBar.rectTransform.sizeDelta = new Vector2 ((1 - percTime) * fullBarSize.x, fullBarSize.y);
	}

	string GenerateAction(int index){
		switch (index) {
		case 0:
			return "UP AND DOWN";
			break;
		case 1:
			return "LEFT AND RIGHT";
			break;
		case 2:
			return "CLOCKWISE";
			break;
		case 3:
			return "COUNTERCLOCKWISE";
			break;
		default:
			return "WUT??";
			break;
		}
	}
}
