using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BunnyHole
{
    public class lostToyEvent : MonoBehaviour
    {
        public GameObject teddy;
        private happinessBar happinessbar;
        public GameObject happinessBarScriptHolder;
        private float xpoint1;
        private float xpoint2;
        private float ypoint1;
        private float ypoint2;
        private bool toyspawned;
        private AudioSource _openAudio;
        private creatureStatus creatureStatusScript;
        private creatureAnims creatureAnimScript;
        private GameObject thoughtBubbleAnim;
        private Animator bubbleAnimator;
        [SerializeField] private GameObject thoughtBubbleText;
        [SerializeField] private GameObject thoughtBubbleImage;
        void Awake()
        {
            happinessbar = happinessBarScriptHolder.GetComponent<happinessBar>();
            xpoint1 = -5.2f;
            xpoint2 = 5.2f;
            ypoint1 = -2f;
            ypoint2 = -0.4f;
            toyspawned = false;
            _openAudio = GetComponent<AudioSource>();
            creatureStatusScript = gameObject.GetComponent<creatureStatus>();
            creatureAnimScript = gameObject.GetComponent<creatureAnims>();
            thoughtBubbleAnim = gameObject.transform.GetChild(1).gameObject;
            bubbleAnimator = thoughtBubbleAnim.GetComponent<Animator>();
            thoughtBubbleText.SetActive(false);
            thoughtBubbleImage.SetActive(false);
        }

        void FixedUpdate()
        {
            if (GameManager.Instance.activityToBeLaunched == 1 && GameManager.Instance.lostToy == false && toyspawned == false)
            {
                float xpos = Random.Range(xpoint1, xpoint2);
                float ypos = Random.Range(ypoint1, ypoint2);
                Vector3 pos = new Vector3(xpos, ypos, -9);
                GameObject instancedTeddy = Instantiate(teddy, pos, Quaternion.identity);
                toyspawned = true;
                bubbleAnimator.SetTrigger("toytrig");
            }
            if (bubbleAnimator.GetCurrentAnimatorStateInfo(0).IsName("thoughtBubbleIdle"))
            {
                thoughtBubbleText.SetActive(true);
                thoughtBubbleImage.SetActive(true);
            }
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            Debug.Log(col.transform.gameObject.name);
            if (col.gameObject.name == "toy(Clone)" && GameManager.Instance.dragging)
            {
                if (_openAudio != null)
                {
                    AudioManager.PlayClip(_openAudio, Config.SoundEffect.PetHappyYoung);
                }
                creatureAnimScript.triggerHappyAnim();
                StartCoroutine("animCooldown");
                GameManager.Instance.happiness += 0.13f;
                StartCoroutine(happinessbar.particle(13));
                thoughtBubbleText.SetActive(false);
                thoughtBubbleImage.SetActive(false);
                bubbleAnimator.SetTrigger("toytrig");
                GameManager.Instance.lostToy = true;
                toyspawned = false;
                GameManager.Instance.dragging = false;
                Destroy(col.gameObject);
            }
        }
        IEnumerator animCooldown()
        {
            yield return new WaitForSeconds(1.5f);
            creatureStatusScript.triggerIdleAnim();
        }
    }
}
