using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class minigame2 : MonoBehaviour {

    // Use this for initialization
    private float t;
    public GameObject button;
    public float timer;
    public float number;
    public float offset;
    public  List<GameObject> buttons;
    void Start ()
    {
        buttons = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        t = t + Time.deltaTime;
        if (t > timer)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                Destroy(buttons[i]);
            }
            for (int i = 1; i <= number; i++)
            {
                GameObject B = Instantiate(button, new Vector3(transform.position.x+offset*i, transform.position.y, transform.position.z), Quaternion.Euler(0f, 0f, 0f)) as GameObject;
                B.GetComponent<Button>().move = false;
                buttons.Add(B);
            }
            t = 0;

        }
    }
}
