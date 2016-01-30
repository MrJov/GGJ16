using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GarbageRoom: MonoBehaviour
{

   

    public GameObject button;
    public Transform position;
    public GameObject limit;
    public Queue<GameObject> buttonQueue;

    public float Spawn;
    private float t;
    bool end = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t = t + Time.deltaTime;
        if (t > Spawn)
        {

            buttonQueue.Enqueue(Instantiate(button, new Vector3(position.position.x, position.position.y, position.position.z), Quaternion.Euler(0f, 0f, 0f)) as GameObject);
            limit.GetComponent<SpriteRenderer>().color = Color.white;
            t = 0;
        }
    }
    

    public void Enabled()
    {
        buttonQueue = new Queue<GameObject>();
        buttonQueue.Enqueue(Instantiate(button, new Vector3(position.position.x, position.position.y, position.position.z), Quaternion.Euler(0f, 0f, 0f)) as GameObject);
    }
    public void Disabled()
    {
       
        t = 0;

    }


}
