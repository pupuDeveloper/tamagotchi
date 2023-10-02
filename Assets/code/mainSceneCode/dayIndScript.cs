using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dayIndScript : MonoBehaviour
{
    [SerializeField] private Image dayInd;
    private float changePoint;
    private Sprite img1;
    private Sprite img2;
    private Sprite img3;
    private Sprite img4;

    void Start()
    {
        img1 = Resources.Load<Sprite>("art/UI/morning");
        img2 = Resources.Load<Sprite>("art/UI/day");
        img3 = Resources.Load<Sprite>("art/UI/evening");
        img4 = Resources.Load<Sprite>("art/UI/night");
        timeChecker();
        changePoint = GameManager.Instance.evolutionLenght / 4;
    }
    void FixedUpdate()
    {
        timeChecker();
    }
    private void timeChecker()
    {
        if (GameManager.Instance.evolutionProgression < changePoint)
        {
            GetComponent<Image>().sprite = img1;
        }
        else if (GameManager.Instance.evolutionProgression > changePoint && GameManager.Instance.evolutionProgression < changePoint * 2)
        {
            GetComponent<Image>().sprite = img2;
        }
        else if (GameManager.Instance.evolutionProgression > changePoint * 2 && GameManager.Instance.evolutionProgression < changePoint * 3)
        {
            GetComponent<Image>().sprite = img3;
        }
        else if (GameManager.Instance.evolutionProgression > changePoint * 3)
        {
            GetComponent<Image>().sprite = img4;
        }
    }
}
