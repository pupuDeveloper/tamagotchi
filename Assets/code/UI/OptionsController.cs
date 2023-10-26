using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BunnyHole
{
    public class OptionsController : MonoBehaviour
    {
        public void OnSave()
        {

        }

        public void OnClose()
        {
            GameManager.Instance.GoBack();
        }
    }
}
