using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BunnyHole
{
    public class OptionsController : MonoBehaviour
    {
        public void OnSave()
        {
            //TODO: Saving mechanics
        }

        public void OnClose()
        {
            GameManager.Instance.GoBack();
        }
    }
}