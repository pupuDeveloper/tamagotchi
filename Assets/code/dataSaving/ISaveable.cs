using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BunnyHole
{

    public interface ISaveable
    {
        string ID { get; set; }
        void Save(BinarySaver writer);
        void Load(BinarySaver reader);
    }
}
