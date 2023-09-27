using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fadeToBlackController : MonoBehaviour
{
    public GameObject blackoutSquare;
    public TMP_Text fadeText;
    private bool fadeIsRunning = false;
    private bool fadeInDone = false;

    void FixedUpdate()
    {
        if (GameManager.Instance.dayProgression >= GameManager.Instance.dayLenght && fadeIsRunning == false)
        {
            StartCoroutine(fade());
        }
        if (GameManager.Instance.dayProgression >= GameManager.Instance.dayLenght && fadeInDone)
        {
            StartCoroutine(fade(false));
        }
    }
    public IEnumerator fade(bool fadetoBlack = true, float fadespeed = 0.45f)
    {
        fadeIsRunning = true;
        Color objectColor = blackoutSquare.GetComponent<Image>().color;
        Color textColor = fadeText.color;
        float fadeAmount;
        if (fadetoBlack)
        {
            while (blackoutSquare.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadespeed * Time.deltaTime);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackoutSquare.GetComponent<Image>().color = objectColor;
                fadeAmount = textColor.a + (fadespeed * Time.deltaTime);
                textColor = new Color(textColor.r, textColor.g, textColor.b, fadeAmount);
                fadeText.color = textColor;
                yield return null;
            }
            yield return new WaitForSeconds(2);
            fadeInDone = true;
        }
        else
        {
            while (blackoutSquare.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadespeed * Time.deltaTime);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackoutSquare.GetComponent<Image>().color = objectColor;
                fadeAmount = textColor.a - (fadespeed * Time.deltaTime);
                textColor = new Color(textColor.r, textColor.g, textColor.b, fadeAmount);
                fadeText.color = textColor;
                yield return null;
            }
            fadeInDone = false;
        }
        fadeIsRunning = false;
    }
}
