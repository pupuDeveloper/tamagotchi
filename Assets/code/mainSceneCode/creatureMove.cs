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

    void Start()
    {
        xpoint1 = -5.2f;
        xpoint2 = 5.2f;
        ypoint1 = -2.5f;
        ypoint2 = -1.5f;
        moveint1 = 5;
        moveint2 = 15;
        movespeed = 1.5f;
        target = new Vector3(0,-2,-9);
        zeroVector = new Vector3(0,-2,-9);
        isTimerRunning = false;
    }
    void Update()
    {
        if (!isTimerRunning && gameObject.transform.position == target)
        {
            StartCoroutine("move");
        }
        if (gameObject.transform.position != target && !isTimerRunning)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, movespeed * Time.deltaTime);
        }
    }

    IEnumerator move()
    {
        isTimerRunning = true;
        Debug.Log("move started");
        moveTime = Random.Range(moveint1, moveint2);
        yield return new WaitForSeconds(moveTime);
        float xpos = Random.Range(xpoint1,xpoint2);
        float ypos = Random.Range(ypoint1,ypoint2); 
        target = new Vector3(xpos, ypos, -9);
        isTimerRunning = false;
        Debug.Log("move completed");
    }
}
