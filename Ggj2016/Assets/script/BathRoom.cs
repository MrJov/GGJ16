using System.Collections.Generic;
using UnityEngine;

public class BathRoom : MonoBehaviour
{

    // Use this for initialization
    // Use this for initialization
    public float t;
    public GameObject button;
    public Transform position;
    public float timer;
    public float number;
    public float offset;
    public List<GameObject> buttons;
    void Start()
    {
        buttons = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        t = t + Time.deltaTime;
        if (t >= timer)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                Destroy(buttons[i]);
            }
            for (int i = 1; i <= number; i++)
            {
                GameObject B = Instantiate(button, new Vector3(position.position.x + offset * i, position.position.y, position.position.z), Quaternion.Euler(0f, 0f, 0f)) as GameObject;
                B.GetComponent<Button>().move = false;
                buttons.Add(B);
            }
            t = 0;

        }
    }

    public void Delete()
    {

        for (int i = 0; i < buttons.Count; i++)
        {
            Destroy(buttons[i]);
        }

    }

    public void Enabled()
    {
        for (int i = 1; i <= number; i++)
        {
            GameObject B = Instantiate(button, new Vector3(position.position.x + offset * i, position.position.y, position.position.z), Quaternion.Euler(0f, 0f, 0f)) as GameObject;
            B.GetComponent<Button>().move = false;
            buttons.Add(B);
        }

    }
    public void Disabled()
    {

        for (int i = 0; i < buttons.Count; i++)
        {
            Destroy(buttons[i]);
        }

    }
}



