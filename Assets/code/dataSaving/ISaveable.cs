using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BunnyHole
{

    public interface ISaveable
    {
        void Save(BinarySaver writer);
        void Load(BinarySaver reader);
    }
}
