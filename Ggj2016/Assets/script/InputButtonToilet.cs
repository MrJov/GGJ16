using System.Collections.Generic;
using UnityEngine;


public class InputButtonToilet : MonoBehaviour
{

    // Use this for initialization
    public string buttonA;
    public string buttonB;
    public string buttonX;
    public string buttonY;
    public GameObject  BathZone;
    BathRoom bath;
    bool active = false;
    public string pressed;
    public List<string> sequence;


    void Start ()
    {
        bath = BathZone.GetComponent<BathRoom>();
        List<string> sequence = new List<string>();
     }
	
	// Update is called once per frame
	void Update ()
    {
        if (active)
        {
            if (Input.GetButton(buttonA))
            {
                sequence.Add("A");
            }
            else
            if (Input.GetButton(buttonB))
            {
                sequence.Add("B");
            }
            else
            if (Input.GetButton(buttonX))
            {
                sequence.Add("C");
            }
            else
            if (Input.GetButton(buttonY))
            {
                sequence.Add("D");
            }
            else
                pressed = "";

        }
    }


	public void Enable()
    {
		
		active = true;
	}

	public void Disable()
    {
		active = false;
	}
}
