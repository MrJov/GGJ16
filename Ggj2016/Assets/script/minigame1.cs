using System.Collections.Generic;
using UnityEngine;

public class minigame1 : MonoBehaviour {

    // Use this for initialization

    public GameObject button;
    public GameObject limit;
    private GameObject b;
   
    public float Spawn;
    private float t;
    bool end = false;
	void Start ()
    {
        GameObject b = Instantiate(button, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0f, 0f, 0f)) as GameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        t = t + Time.deltaTime;
        if (t>Spawn)
        {
            
            GameObject b = Instantiate(button, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0f, 0f, 0f)) as GameObject;
           
            t = 0;
        }
    }

    public GameObject getbutton()
    {

        return b;
    }



}



