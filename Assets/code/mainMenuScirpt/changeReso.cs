using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class changeReso : MonoBehaviour
{
    public List<ResItem> resolutions = new List<ResItem>();
    private int selectedResolution;
    public TMP_Text resolutionLabel;

    void Start()
    {
        bool foundRes = false;
        for (int i = 0; i < resolutions.Count; i++)
        {
            if(Screen.width == resolutions[i].sideLenght)
            {
                foundRes = true;
                selectedResolution = i;
                UpdateResLabel();
            }
        }
    }

    public void ResLeft()
    {
        selectedResolution--;
        if (selectedResolution < 0)
        {
            selectedResolution = 0;
        }
        UpdateResLabel();
    }

    public void ResRight()
    {
        selectedResolution++;
        if (selectedResolution > resolutions.Count - 1)
        {
            selectedResolution = resolutions.Count - 1;
        }
        UpdateResLabel();
    }
    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedResolution].sideLenght.ToString() + " x " + resolutions[selectedResolution].sideLenght.ToString();
        Screen.SetResolution(resolutions[selectedResolution].sideLenght, resolutions[selectedResolution].sideLenght, false);
    }
}


[System.Serializable]
public class ResItem
{
    public int sideLenght;
}