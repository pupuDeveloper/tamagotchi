using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BunnyHole
{
    public class creatureAnims : MonoBehaviour
    {
        private creatureStatus creatureStatusScript;

        void Awake()
        {
            creatureStatusScript = gameObject.GetComponent<creatureStatus>();
        }

        public void triggerHappyAnim()
        {
            gameObject.GetComponent<Animator>().SetBool("sadanim", false);
            gameObject.GetComponent<Animator>().SetBool("happyanim", true);
        }
        public void triggerSadAnim()
        {
            gameObject.GetComponent<Animator>().SetBool("happyanim", false);
            gameObject.GetComponent<Animator>().SetBool("sadanim", true);
        }
    }
}
