using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lostToyEvent : MonoBehaviour
{
    [SerializeField] private Sprite teddyNormal;
    [SerializeField] private Sprite teddyHover;
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
        if (GameManager.Instance.activityToBeLaunched == 1 && GameManager.Instance.lostToy == false && !toyspawned)
        {
            float xpos = Random.Range(xpoint1,xpoint2);
            float ypos = Random.Range(ypoint1,ypoint2); 
            Vector2 pos = new Vector2(xpos, ypos);
            GameObject instancedTeddy = Instantiate(teddy, pos, Quaternion.identity);
            toyspawned = true;
        }
    }

    void OnMouseDown()
    {
        GameManager.Instance.happiness += 0.175f;
        happinessbar.UpdateHappinessBar();
        GameManager.Instance.lostToy = true;
        toyspawned = false;
    }
    void OnMouseOver()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = teddyHover;
    }

    void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = teddyNormal;
    }
}
