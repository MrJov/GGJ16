using UnityEngine;
using System.Collections;

public class InputButtonTrash : MonoBehaviour {

    // Use this for initialization

    public string buttonA;
    public string buttonB;
    public string buttonX;
    public string buttonY;
    public GameObject GarbageZone;
    GarbageRoom garbage;
	bool active = false;
    bool green = false;

    void Start () {
        garbage = GarbageZone.GetComponent<GarbageRoom>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (active && garbage.buttonQueue.Count>0)
        {
            Debug.Log("Active");

            if (garbage.buttonQueue.Peek().GetComponent<Button>().pressed)
            {
                if (garbage.buttonQueue.Peek().GetComponent<Button>().getType().Equals("A") && Input.GetButton(buttonA))
                {
                    green = true;
                    garbage.limit.GetComponent<SpriteRenderer>().color = Color.green;
                }
                else
                if (garbage.buttonQueue.Peek().GetComponent<Button>().getType().Equals("B") && Input.GetButton(buttonB))
                {
                    green = true;
                    garbage.limit.GetComponent<SpriteRenderer>().color = Color.green;
                }
                else
                if (garbage.buttonQueue.Peek().GetComponent<Button>().getType().Equals("X") && Input.GetButton(buttonX))
                {
                    green = true;
                    garbage.limit.GetComponent<SpriteRenderer>().color = Color.green;

                }
                else
                if (garbage.buttonQueue.Peek().GetComponent<Button>().getType().Equals("Y") && Input.GetButton(buttonY))
                {
                    green = true;
                    garbage.limit.GetComponent<SpriteRenderer>().color = Color.green;

                }
                
                Debug.Log("clear");
                if (!green)
                    garbage.limit.GetComponent<SpriteRenderer>().color = Color.red;
                else {
                    garbage.limit.GetComponent<SpriteRenderer>().color = Color.green;
                    green = false;
                }
                Destroy(garbage.buttonQueue.Dequeue());
            }

           

        }
        }
    public void Enable()
    {

        garbage = GarbageZone.GetComponent<GarbageRoom>();
        garbage.limit.GetComponent<SpriteRenderer>().color = Color.white;
        active = true;

    }

    public void Disable()
    {
        if(active)
            for(int i=0;i<garbage.buttonQueue.Count;i++)
                Destroy(garbage.buttonQueue.Dequeue());

        active = false;

    }
}

