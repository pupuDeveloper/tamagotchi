using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBackground : MonoBehaviour
{
    public GameObject background;
    private bool hovering;

    public void onOver()
    {
        hovering = true;
    }
    public void onExit()
    {
        hovering = false;
    }
    void Update()
    {
        if (hovering)
        {
            if (this.gameObject.name == "right" && background.transform.position.x < 2.7)
            {
                background.transform.position += new Vector3(7 * Time.deltaTime, 0, 0);
            }
            else if (this.gameObject.name == "left" && background.transform.position.x > -2.7)
            {
                background.transform.position -= new Vector3(7 * Time.deltaTime, 0, 0);
            }
        }
    }
}

