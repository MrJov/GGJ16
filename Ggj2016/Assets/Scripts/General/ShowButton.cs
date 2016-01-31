using UnityEngine;
using System.Collections;

public class ShowButton : MonoBehaviour {

	public GameObject green;
	public GameObject normal;
	public GameObject red;
	public string letter;

	public void ShowNormal(){
		normal.SetActive (true);
		green.SetActive (false);
		red.SetActive (false);
	}

	public void ShowGreen(){
		normal.SetActive (false);
		green.SetActive (true);
		red.SetActive (false);
	}

	public void ShowRed(){
		normal.SetActive (false);
		green.SetActive (false);
		red.SetActive (true);
	}

	public void HideAll(){
		normal.SetActive (false);
		green.SetActive (false);
		red.SetActive (false);
	}

	public string GetLetter(){
		return letter;
	}
}
