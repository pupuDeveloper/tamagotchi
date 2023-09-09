using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class moveBackground : MonoBehaviour
{
    public GameObject background;
    public Button right;
    public Button left;
    

    public void buttonActions()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "right" && background.transform.position.x > -10)
        {
            background.transform.position -= new Vector3 (10, 0, 0);
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "left" && background.transform.position.x < 10)
        {
            background.transform.position += new Vector3 (10, 0, 0);
        }
    }
}
