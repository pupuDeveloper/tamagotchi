using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SaveSystem
{
    public SaveSystem()
    {
        try
        {
            if (!Directory.Exists(SaveFolder))
            {
                Directory.CreateDirectory(SaveFolder);
            }
        }
        catch(Exception e)
        {
            Debug.LogException(e);
        }
    }

    public string SaveFolder
    {
        get
        {
            string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return Path.Combine(documents, "PetLab", "Save");
        }
    }

    public string QuickSave {get {return "QuickSave"; } }

    public string FileExtension { get {return ".save"; } }
}
