using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BunnyHole
{
    public class happinessBar : MonoBehaviour
    {

        [SerializeField] private Image happinessbarFill;
        [SerializeField] private Animator barAnimator;
        [SerializeField] private ParticleSystem successParticle;

        void Awake()
        {
            UpdateHappinessBar();
            if (GameManager.Instance.returningFromMinigame && GameManager.Instance.minigameWasSuccess)
            {
                GameManager.Instance.returningFromMinigame = false;
                StartCoroutine("minigameCD");
            }
        }

        void Update()
        {
            if (barAnimator != null)
            {
                if (GameManager.Instance.happiness < 0.4)
                {
                    barAnimator.SetTrigger("LowHealth");
                }
                else if (GameManager.Instance.happiness > 0.4)
                {
                    barAnimator.SetTrigger("StableHealth");
                }
            }
        }

        //this function adds or subtracts happiness points from the bar. 0 is 0 and 1 is full (0.5 is half bar)
        public void UpdateHappinessBar()
        {
            happinessbarFill.fillAmount = GameManager.Instance.happiness;
        }
        public IEnumerator particle(int amount)
        {
            successParticle.Clear();
            successParticle.maxParticles = amount;
            float timeInBetween = 0.05f;
            for (int i = 0; i < amount; i++)
            {
                successParticle.Play();
                happinessbarFill.fillAmount += 0.01f;
                yield return new WaitForSeconds(timeInBetween);
            }
            yield return new WaitForSeconds(0.3f);
            successParticle.Stop();
        }
        IEnumerator minigameCD()
        {
            yield return new WaitForSeconds(1);
            StartCoroutine("particle", 15);
            yield return new WaitForSeconds(1f);
            GameManager.Instance.happiness += 0.15f;
        }
    }
}
