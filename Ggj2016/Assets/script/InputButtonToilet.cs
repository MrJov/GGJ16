using UnityEngine;
using System.Collections;

public class InputButtonToilet : MonoBehaviour {

    // Use this for initialization

    public string buttonA;
    public string buttonB;
    public string buttonX;
    public string buttonY;
    public GameObject BathroomZone;
    minigame2 toilete;
    int count = 0;


    void Start () {
        toilete = BathroomZone.GetComponent<minigame2>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButton(buttonA) && toilete.buttons[count].GetComponent<Button>().getType().Equals("A"))
        {

            count++;

        }
        else
        if (Input.GetButton(buttonB) && toilete.buttons[count].GetComponent<Button>().getType().Equals("B"))
        {
            count++;

        }
        else

        if (Input.GetButton(buttonX) && toilete.buttons[count].GetComponent<Button>().getType().Equals("X"))
        {

            count++;

        }
        else
        if (Input.GetButton(buttonY) && toilete.buttons[count].GetComponent<Button>().getType().Equals("Y"))
        {
            count++;

        }
        else
            count = 0;


    }
}

