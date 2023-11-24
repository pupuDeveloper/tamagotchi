using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;

namespace BunnyHole
{

    public class SaveSystem
    {
        private BinarySaver _saver;
        public SaveSystem()
        {
            try
            {
                if (!Directory.Exists(SaveFolder))
                {
                    Directory.CreateDirectory(SaveFolder);
                }
            }
            catch (Exception e)
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

        public string mainSaveSlot { get { return "mainSaveSlot"; } }

        public string FileExtension { get { return ".save"; } }

        public void Save(string slot)
        {
            _saver = new BinarySaver();
            string saveFilePath = Path.Combine(SaveFolder, slot + FileExtension);
            _saver.PrepareWrite(saveFilePath);

            //TODO: the actual saving
            GameManager.Instance.Save(_saver);

            ISaveable[] saveables = GameObject
            .FindObjectsOfType<MonoBehaviour>(includeInactive: true)
            .OfType<ISaveable>()
            .ToArray();

            //how many objects are saved
            _saver.WriteInt(saveables.Length);

            foreach (ISaveable saveable in saveables)
            {
                saveable.Save(_saver);
            }

            _saver.FinalizeWrite();
        }

        public void Load(string slot)
        {
            _saver = new BinarySaver();
            string saveFilePath = Path.Combine(SaveFolder, slot + FileExtension);
            _saver.PrepareRead(saveFilePath);

            GameManager.Instance.Load(_saver);
            //TODO: load the data
        }
    }
}
