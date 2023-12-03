using System.Collections;
using UnityEngine;

namespace BunnyHole
{
	public class IntroController : MonoBehaviour
	{
		[SerializeField] private Animator _animator;

        private void Start()
        {
            StartCoroutine(PlayAnimation());
        }

        private IEnumerator PlayAnimation()
        {
            _animator.Play("DarkIntroAnimation");
            yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length + 1.8f);
            ExitIntro();
        }

        private void ExitIntro()
        {
            GameManager.Instance.Go(States.StateType.MainMenu);
        }
    }
}