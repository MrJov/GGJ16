using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Kitchen : MonoBehaviour {
	[System.Serializable]
	public struct Actions
	{
		public GameObject buttonSequence;
		public string actionName;
	}

	public float actionTime = 3f;
	GameObject activePlayer;
	public Actions[] possibleActions = new Actions[4];

	Vector2 fullBarSize;
	float elapsedTime = 0f;
	float correctTime = 0f;
	Actions action;
	bool active = false;

	// Use this for initialization
	void Start () {
		action = ChangeAction (Random.Range (0, 4));
		/*possibleActions [Random.Range (0, 4)];*/
		action.buttonSequence.GetComponent<ShowButton> ().ShowNormal ();
		elapsedTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			if (elapsedTime > actionTime) {
				action = ChangeAction (Random.Range (0, 4));
				action.buttonSequence.GetComponent<ShowButton> ().ShowNormal ();
				float percCorrect = correctTime / actionTime;
				if (percCorrect >= .5f) {
					FindObjectOfType<RewardManager> ().Increment ();
				}
				correctTime = 0f;
				elapsedTime = 0f;
			} else {
				elapsedTime += Time.deltaTime;
			}
			string actionPerf = activePlayer.GetComponent<KitchenController> ().GetPlayerAction ();
			//Debug.Log (actionPerf);
			if (action.actionName.Equals (actionPerf)) {
				action.buttonSequence.GetComponent<ShowButton> ().ShowGreen ();
				correctTime += Time.deltaTime;
			} else {
				action.buttonSequence.GetComponent<ShowButton> ().ShowRed ();
			}
		}
	}

	Actions ChangeAction(int index){
		Actions act = new Actions();
		for (int i = 0; i < possibleActions.Length; i++) {
			if (i == index) {
				act = possibleActions [i];
			} else {
				possibleActions [i].buttonSequence.GetComponent<ShowButton> ().HideAll ();
			}
		}

		return act;
	}

	public void SetActivePlayer(GameObject player){
		activePlayer = player;
		elapsedTime = 0f;
		action = ChangeAction (Random.Range (0, 4));
		action.buttonSequence.GetComponent<ShowButton> ().ShowNormal ();
		active = true;
	}

	public void Reset(){
		active = false;
		for (int i = 0; i < possibleActions.Length; i++) {
			possibleActions [i].buttonSequence.GetComponent<ShowButton> ().HideAll ();

		}
	}
}
