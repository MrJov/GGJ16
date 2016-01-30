using UnityEngine;
using System.Collections;

public class InputButtonToilet : MonoBehaviour
{

    // Use this for initialization
    public string buttonA;
    public string buttonB;
    public string buttonX;
    public string buttonY;
	public GameObject BathroomZone;
    Minigame1 garbage;
	bool active = false;


    void Start ()
    {
		garbage=BathroomZone.GetComponent<Minigame1>();


    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetButton(buttonA))
        {
          
            if (garbage.getbutton().GetComponent<Button>().GetType().Equals("A") && garbage.getbutton().GetComponent<Button>().pressed)
            {
                Debug.Log("great");
            }

        }
      
        if (Input.GetButton(buttonB))
        {
            if (garbage.getbutton().GetComponent<Button>().GetType().Equals("B") && garbage.getbutton().GetComponent<Button>().pressed)
            {
                Debug.Log("great");
            }

        }
   
        if (Input.GetButton(buttonX))
        {

            if (garbage.getbutton().GetComponent<Button>().GetType().Equals("X") && garbage.getbutton().GetComponent<Button>().pressed)
            {
                Debug.Log("great");
            }

        }
      
        if (Input.GetButton(buttonY))
        {
            if (garbage.getbutton().GetComponent<Button>().GetType().Equals("Y") && garbage.getbutton().GetComponent<Button>().pressed)
            {
                Debug.Log("great");
            }

        }
    }


	public void Enable(){
		garbage=BathroomZone.GetComponent<Minigame1>();
		active = true;
	}

	public void Disable(){
		active = false;
	}
}
