using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace BunnyHole
{
    public class fadeToBlackController : MonoBehaviour
    {
        public GameObject blackoutSquare;
        public TMP_Text fadeText;
        private bool fadeIsRunning = false;
        private bool fadeInDone = false;

        void FixedUpdate()
        {
            if (GameManager.Instance.evolutionProgression >= GameManager.Instance.evolutionLenght && fadeIsRunning == false)
            {
                StartCoroutine(Dayfade());
            }
            if (GameManager.Instance.evolutionProgression >= GameManager.Instance.evolutionLenght && fadeInDone)
            {
                StartCoroutine(Dayfade(false));
            }
        }
        public IEnumerator Dayfade(bool fadetoBlack = true, float fadespeed = 0.45f)
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
        //TODO: game lose and win fades and stuff
        /*public IEnumerator gameWinFade(winFadeBool = true, float fadespeed = 0.45f)
        {

        }
        public IEnumerator gameLoseFade(loseFadebool = true, float fadespeed 0.45f)
        {

        }*/
    }
}
