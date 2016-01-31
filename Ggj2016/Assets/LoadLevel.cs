using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

    // Use this for initialization
    float t = 0f;
    float show = 1f;
    float dontShow = 0.5f;
    bool active = true;
    public GameObject start;
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetButton("Player_1_A") || Input.GetButton("Player_2_A") || Input.GetButton("Player_3_A") || Input.GetButton("Player_4_A"))
            Application.LoadLevel("Main");

        t += Time.deltaTime;

        if (t > show && active)
        {
            t = 0;
            start.SetActive(false);
            active = false;
        }

        if (t > dontShow && !active)
        {
            t = 0;
            start.SetActive(true);
            active = true;
        }




    }
}
