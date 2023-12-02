using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BunnyHole;
using System;

public class loadPastPets : MonoBehaviour
{
    [SerializeField] private GameObject listPrefab;
    [SerializeField] private GameObject gridcontent;
    private Animator graveyardAnimator;
    private TMP_Text nametext;
    private TMP_Text agetext;
    private TMP_Text status;

    void Start()
    {
        for (int i = 0; i < GameManager.Instance.petCollection.Count; i++)
        {
            
            GameObject instancedListItem = Instantiate(listPrefab, gridcontent.transform);

            graveyardAnimator = instancedListItem.transform.GetChild(0).GetComponent<Animator>();
            nametext = instancedListItem.transform.GetChild(1).GetComponent<TMP_Text>();
            agetext = instancedListItem.transform.GetChild(2).GetComponent<TMP_Text>();
            status = instancedListItem.transform.GetChild(3).GetComponent<TMP_Text>();

            if (GameManager.Instance.petCollection[i].ageInSeconds < 100f)
            {
                switch(GameManager.Instance.petCollection[i].type)
                {
                    case 1:
                    graveyardAnimator.SetInteger("which anim", 1);
                    break;
                    case 2:
                    graveyardAnimator.SetInteger("which anim", 2);
                    break;
                    case 3:
                    graveyardAnimator.SetInteger("which anim", 3);
                    break;
                }
            }
            else
            {
                switch(GameManager.Instance.petCollection[i].type)
                {
                    case 1:
                    graveyardAnimator.SetInteger("which anim", 4);
                    break;
                    case 2:
                    graveyardAnimator.SetInteger("which anim", 5);
                    break;
                    case 3:
                    graveyardAnimator.SetInteger("which anim", 6);
                    break;
                }
            }
            nametext.text = GameManager.Instance.petCollection[i].petName;
            int age = (int)Math.Round(GameManager.Instance.petCollection[i].ageInSeconds, 0);

            float hours = TimeSpan.FromSeconds(GameManager.Instance.petCollection[i].ageInSeconds).Hours;
            float minutes = TimeSpan.FromSeconds(GameManager.Instance.petCollection[i].ageInSeconds).Minutes;
            float seconds = TimeSpan.FromSeconds(GameManager.Instance.petCollection[i].ageInSeconds).Seconds;
            string textFieldHours = hours.ToString();
            string textFieldMinutes = minutes.ToString();
            string textFieldSeconds = minutes.ToString();
            agetext.text = "age\n" + hours + " day\n" + minutes + " h\n" + seconds + " min";


            if (GameManager.Instance.petCollection[i].state == 1)
            {
                status.text = "Dead";
            }
            else if (GameManager.Instance.petCollection[i].state == 2)
            {
                status.text = "Abandoned";
            }
        }
    }
}
