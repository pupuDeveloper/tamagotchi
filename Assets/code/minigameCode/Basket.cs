using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GA.BunnyHole.Generated;

namespace BunnyHole
{
    public class Basket : MonoBehaviour
    {
        private Inputs _inputs;

        private void Awake()
        {
            _inputs = new Inputs();
        }

        private void OnEnable()
        {
            //Enable inputs
            _inputs.Basket.Enable();
        }

        private void OnDisable()
        {
            //Disable inputs
            _inputs.Basket.Disable();
        }

        private void Update()
        {
            //Reads the movement
            Vector2 moveInput = _inputs.Basket.Move.ReadValue<Vector2>();
            Debug.Log("Movement: " + moveInput);
        }

    }
}
