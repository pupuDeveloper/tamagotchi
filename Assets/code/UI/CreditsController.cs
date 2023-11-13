using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BunnyHole.UI
{
    public class CreditsController : MonoBehaviour
    {
        public void OnClose()
        {
            GameManager.Instance.GoBack();
        }
    }
}
