using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GarbageRoom: MonoBehaviour
{
    public GameObject button;
    public Transform position;
    public GameObject limit;
    GameObject buttonSpawn;
    public GameObject activePlayer;

    public float Spawn;
    bool istanced=false;
    bool enable = false;

    void Start()
    {
	
    }

    // Update is called once per frame
    void Update()
    {
     
        if (enable)
        {

            if(buttonSpawn.GetComponent<Button>().pressed)
            {
                if (activePlayer.GetComponent<InputButtonTrash>().pressed.Equals(buttonSpawn.GetComponent<Button>().getType()))
                    limit.GetComponent<SpriteRenderer>().color = Color.green;

            }
            else
                if (buttonSpawn.GetComponent<Button>().end)
            {
                Destroy(buttonSpawn);
                buttonSpawn =Instantiate(button, new Vector3(position.position.x, position.position.y, position.position.z), Quaternion.Euler(0f, 0f, 0f)) as GameObject;
                limit.GetComponent<SpriteRenderer>().color = Color.white;
                buttonSpawn.GetComponent<Button>().move = true;
            }

          
        }
        
    }
    

    public void Enabled(GameObject Player)
    {
        enable = true;
        activePlayer = Player;
        buttonSpawn = Instantiate(button, new Vector3(position.position.x, position.position.y, position.position.z), Quaternion.Euler(0f, 0f, 0f)) as GameObject;
        buttonSpawn.GetComponent<Button>().move = true;
    }
    public void Disabled()
    {
        if(buttonSpawn!=null)
            Destroy(buttonSpawn);

        enable = false;


    }


}
