using UnityEngine;
using System.Collections;

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
    private int count=0;


    void Start ()
    {
        bath = BathZone.GetComponent<BathRoom>();


    }
	
	// Update is called once per frame
	void Update ()
    {
        if (active && bath.buttons[count] != null)
        {
            if (Input.GetButton(buttonA) && bath.buttons[count].gameObject.GetComponent<Button>().getType().Equals("A"))
            {
                count++;

            }
            else
            if (Input.GetButton(buttonB) && bath.buttons[count].gameObject.GetComponent<Button>().getType().Equals("B"))
            {
                count++;
            }
            else
            if (Input.GetButton(buttonX) && bath.buttons[count].gameObject.GetComponent<Button>().getType().Equals("X"))
            {
                count++;
            }
            else
            if (Input.GetButton(buttonY) && bath.buttons[count].gameObject.GetComponent<Button>().getType().Equals("Y"))
            {
                count++;

            }
            else
            {
                if (bath.buttons[count]!=null)
                {
                    switch (bath.buttons[count].gameObject.GetComponent<Button>().getType())
                    {
                        case "A":
                            bath.buttons[count].gameObject.GetComponent<Button>().GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Buttons/A_red-01");

                            break;
                        case "B":
                            bath.buttons[count].gameObject.GetComponent<Button>().GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Buttons/B_red-01");
                            break;
                        case "X":
                            bath.buttons[count].gameObject.GetComponent<Button>().GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Buttons/X_red-01");

                            break;
                        case "Y":
                            bath.buttons[count].gameObject.GetComponent<Button>().GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Buttons/Y_red-01");

                            break;
                    }
                    count = 0;
                    bath.t = bath.timer;
                }
            }



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
