using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lostToyEvent : MonoBehaviour
{
    public GameObject teddy;
    private happinessBar happinessbar;
    public GameObject happinessBarScriptHolder;
    private float xpoint1;
    private float xpoint2;
    private float ypoint1;
    private float ypoint2;
    private bool toyspawned;
    void Awake()
    {
        happinessbar = happinessBarScriptHolder.GetComponent<happinessBar>();
        xpoint1 = -5.2f;
        xpoint2 = 5.2f;
        ypoint1 = -2.5f;
        ypoint2 = -1.5f;
        toyspawned = false;
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.activityToBeLaunched == 1 && GameManager.Instance.lostToy == false && toyspawned == false)
        {
            float xpos = Random.Range(xpoint1, xpoint2);
            float ypos = Random.Range(ypoint1, ypoint2); 
            Vector2 pos = new Vector2(xpos, ypos);
            GameObject instancedTeddy = Instantiate(teddy, pos, Quaternion.identity);
            toyspawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.transform.gameObject.name);
        if (col.gameObject.name == "toy(Clone)" && GameManager.Instance.dragging)
        {
            GameManager.Instance.happiness += 0.125f;
            happinessbar.UpdateHappinessBar();
            GameManager.Instance.lostToy = true;
            toyspawned = false;
            GameManager.Instance.dragging = false;
            Destroy(col.gameObject);
        }
    }
}
