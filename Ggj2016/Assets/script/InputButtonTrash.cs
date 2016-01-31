using UnityEngine;
using System.Collections;

public class InputButtonTrash : MonoBehaviour {

    // Use this for initialization

    public string buttonA;
    public string buttonB;
    public string buttonX;
    public string buttonY;
	bool active = false;
    bool green = false;
    public string pressed;

    void Start () {
       
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (active)
        {
            if (Input.GetButton(buttonA))
            {
                pressed = "A";
            }

            if (Input.GetButton(buttonB))
            {
                pressed = "B";
            }

            if (Input.GetButton(buttonX))
            {
                pressed = "X";
            }

            if (Input.GetButton(buttonY))
            {
                pressed = "Y";
            }
        }

               
   }

           

        
        
    public void Enable()
    { 
        active = true;

    }

    public void Disable()
    {
        if(active)
            

        active = false;

    }
}

