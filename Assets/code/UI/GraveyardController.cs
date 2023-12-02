using UnityEngine;


namespace BunnyHole.UI
{
    public class GraveyardController : MonoBehaviour
    {
        public void OnClose()
        {
            GameManager.Instance.GoBack();
        }
    }
}