using UnityEngine;
using System.Collections;

public class GarbageController : MonoBehaviour {

	public string buttonA;
	public string buttonB;
	public string buttonX;
	public string buttonY;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string[] GetButtons(){
		return new string[]{ buttonA, buttonB, buttonX, buttonY };
	}
}
