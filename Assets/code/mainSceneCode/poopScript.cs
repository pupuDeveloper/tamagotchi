using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poopScript : MonoBehaviour
{
    private bool isRoomClean;
    private bool isCoroutineRunning;
    public int spawnInterval1;
    public int spawnInterval2;
    public GameObject poopPrefab;

    //fixedupdate checks how many poops are in the screen from gamemanager, and also checks if a timer is running
    //before running the spawner script
    void FixedUpdate()
    {
        if (GameManager.Instance.poopAmount < 5 && isCoroutineRunning == false)
        {
            StartCoroutine("spawnPoops");
        }
    }

    //IEnumerator coroutine randomises time between spawnInterval1 and Spawninterval2
    //Then it randomises position
    //Then it creates a copy of the poop prefab and spawns it to the screen
    IEnumerator spawnPoops()
    {
        isCoroutineRunning = true;
        int spawnTime = Random.Range(spawnInterval1, spawnInterval2);
        yield return new WaitForSeconds (spawnTime);
        Vector2 pos = new Vector2(Random.Range(-4.5f, 5f), Random.Range(-3f,3f));
        Instantiate(poopPrefab, pos, Quaternion.identity);
        GameManager.Instance.poopAmount++;
        Debug.Log(GameManager.Instance.poopAmount);
        isCoroutineRunning = false;
    }
}
