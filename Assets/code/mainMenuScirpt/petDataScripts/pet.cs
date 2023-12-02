using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

namespace BunnyHole
{
    [System.Serializable]
    public class pet : ISaveable
    {
        public string petName;
        public float ageInSeconds;
        public int type;
        public int state;

        public pet(string petName, float ageInSeconds, int type, int state)
        {
            this.petName = petName;
            this.ageInSeconds = ageInSeconds;
            this.type = type;
            this.state = state;
        }
        public void Save(BinarySaver writer)
        {
            writer.WriteString(petName);
            writer.WriteFloat(ageInSeconds);
            writer.WriteInt(type);
            writer.WriteInt(state);
        }
        public void Load(BinarySaver reader)
        {
            petName = reader.ReadString();
            ageInSeconds = reader.ReadFloat();
            type = reader.ReadInt();
            state = reader.ReadInt();
        }
    }
}

