using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BunnyHole
{

    public class poopDestroyingScript : MonoBehaviour
    {

        private poopScript poopscript;
        private happinessBar happinessbar;
        private Animator cleaningAnim;
        private GameObject cleaninOb;

        void Awake()
        {
            poopscript = GameObject.Find("poopSpawner").GetComponent<poopScript>();
            happinessbar = GameObject.Find("happinesbarBackground").GetComponent<happinessBar>();
            cleaninOb = GameObject.Find("poopSpawner");
            cleaningAnim = cleaninOb.GetComponentInChildren<Animator>(true);
        }
        void OnMouseDown()
        {
            if (poopscript.isCleaningOn)
            {
                Vector2 pos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.22f);
                cleaninOb.transform.position = pos;
                GameManager.Instance.poops.Remove(gameObject.transform.position);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GameManager.Instance.happiness += 0.03f;
                StartCoroutine(happinessbar.particle(3));
                cleaningAnim.SetTrigger("clean");
                StartCoroutine("destroyDelay");
            }
        }
        IEnumerator destroyDelay()
        {
            yield return new WaitForSeconds(0.46f);
            Destroy(gameObject);
        }
    }
}
