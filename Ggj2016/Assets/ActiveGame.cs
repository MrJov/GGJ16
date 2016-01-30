using UnityEngine;
using System.Collections;

public class ActiveGame : MonoBehaviour
{

    public GameObject buttonPosition;
    // Use this for initialization
    public GameObject Room;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (Room.name.Equals("GarbageZone"))
        {

            other.gameObject.GetComponent<InputButtonThresh>().enabled = true;
            buttonPosition.GetComponent<minigame2>().enabled = true;
        }
        else

         if (Room.gameObject.name.Equals("BathroomZone"))
        {

            other.gameObject.GetComponent<InputButtonToilet>().enabled = true;
            buttonPosition.GetComponent<minigame1>().enabled = true;
        }



    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (Room.name.Equals("GarbageZone"))
        {

            other.gameObject.GetComponent<InputButtonThresh>().enabled = false;
            buttonPosition.GetComponent<minigame2>().enabled = false;
        }
        else

         if (Room.name.Equals("BathroomZone"))
        {

            other.gameObject.GetComponent<InputButtonToilet>().enabled = false;
            buttonPosition.GetComponent<minigame1>().enabled = false;
        }
    }
}
