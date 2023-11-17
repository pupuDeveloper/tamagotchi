using System.Collections;
using UnityEngine;

namespace BunnyHole.UI
{
	public class IntroController : MonoBehaviour
	{
		private Animator _animator;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        private void Start()
        {
            PlayAnimation();
        }

        private void PlayAnimation()
        {
            _animator.Play("IntroAnimation");
        }
    }
}