using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    // Use this for initialization

    public bool end = false;
    private string type;
    public  bool move = false;
    public bool pressed=false;
 

	void Start ()
    {
        int rand = Random.Range(0, 4);
        switch (rand)
        {
            case 0:
                type = "A";
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("a_normal-01");
                break;
            case 1:
                type = "B";
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("b_normal-01");
                break;
           case 2:
                type = "Y";
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("y_normal-01");
                break;

           case 3:
                type = "X";
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("x_normal-01");
                break;
        }


    }
	
	// Update is called once per frame
	void Update ()
    {
        if (move)
        {
            if (!end)
                transform.position = new Vector3((transform.position.x - 0.1f), transform.position.y, transform.position.z);
          
                
        }

        if (end)
            Destroy(gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        pressed = false;
        end = true;
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        pressed = true;

    }

    public bool getEnd()
    {
        return end;
    }

    public string getType()
    {
        return type;
    }


}
