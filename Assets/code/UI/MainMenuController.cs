using UnityEngine;
using UnityEngine.Audio;

namespace BunnyHole.UI
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject _namePet;
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private Sprite childsprite1;
        [SerializeField] private Sprite childsprite2;
        [SerializeField] private Sprite childsprite3;
        [SerializeField] private Sprite adultsprite1;
        [SerializeField] private Sprite adultsprite2;
        [SerializeField] private Sprite adultsprite3;
        [SerializeField] private VolumeControl _masterVolume;
        [SerializeField] private VolumeControl _musicVolume;
        [SerializeField] private VolumeControl _sfxVolume;
        [SerializeField] private AudioMixer _mixer;

        public void OnNewGame()
        {
            switch (GameManager.Instance.currentPet.type)
            {
                case 1:
                GameManager.Instance.currentPet.childSprite = childsprite1;
                GameManager.Instance.currentPet.adultSprite = adultsprite1;
                break;
                case 2:
                GameManager.Instance.currentPet.childSprite = childsprite2;
                GameManager.Instance.currentPet.adultSprite = adultsprite2;
                break;
                case 3:
                GameManager.Instance.currentPet.childSprite = childsprite3;
                GameManager.Instance.currentPet.adultSprite = adultsprite3;
                break;
                case 0:
                break;
            }

            if (GameManager.Instance.activePet)
            {
                GameManager.Instance.gameIsPaused = false;
                GameManager.Instance.Go(States.StateType.MainScene);
            }
            else
            {
                _namePet.SetActive(true);
                _mainMenu.SetActive(false);
            }
        }

        public void OnOptions()
        {
            GameManager.Instance.Go(States.StateType.Options);
        }

        public void OnCredits()
        {
            GameManager.Instance.Go(States.StateType.Credits);
        }

        public void OnQuit()
        {
            Application.Quit();
        }
    }

}
