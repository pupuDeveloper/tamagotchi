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
            _animator.Play("IntroAnimation");
            yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length + 2);
            ExitIntro();
        }

        private void ExitIntro()
        {
            GameManager.Instance.Go(States.StateType.MainMenu);
        }
    }
}