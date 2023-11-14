using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatureMove : MonoBehaviour
{
    private bool isTimerRunning;
    private float xpoint1;
    private float xpoint2;
    private float ypoint1;
    private float ypoint2;
    private int moveTime;
    private int moveint1;
    private int moveint2;
    private float movespeed;
    private Vector3 target;
    private Vector3 zeroVector;
    [SerializeField] GameObject poopObject;
    private poopScript poopscript;

    void Start()
    {
        xpoint1 = -4.5f;
        xpoint2 = 4.5f;
        ypoint1 = -1.5f;
        ypoint2 = -0.25f;
        moveint1 = 2;
        moveint2 = 10;
        movespeed = 1.5f;
        target = new Vector3(0,-1,-9);
        zeroVector = new Vector3(0,-1,-9);
        isTimerRunning = false;
        poopscript = poopObject.GetComponent<poopScript>();
    }
    void Update()
    {
        if(poopscript.poopHasSpawned)
        {
            poopscript.poopHasSpawned = false;
            StopCoroutine("move");
            moveWhenPooped();
        }
        if (!isTimerRunning && gameObject.transform.position == target)
        {
            StartCoroutine("move");
        }
        if (gameObject.transform.position != target)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, movespeed * Time.deltaTime);
        }
    }

    IEnumerator move()
    {
        isTimerRunning = true;
        moveTime = Random.Range(moveint1, moveint2);
        yield return new WaitForSeconds(moveTime);
        float xpos = Random.Range(xpoint1,xpoint2);
        float ypos = Random.Range(ypoint1,ypoint2); 
        target = new Vector3(xpos, ypos, -9);
        isTimerRunning = false;
    }
    private void moveWhenPooped()
    {
        float xpos = Random.Range(xpoint1,xpoint2);
        float ypos = Random.Range(ypoint1,ypoint2); 
        target = new Vector3(xpos, ypos, -9);
    }
}
