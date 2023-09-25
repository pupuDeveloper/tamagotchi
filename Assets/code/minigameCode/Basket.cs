using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GA.BunnyHole.Generated;

namespace BunnyHole
{
    public class Basket : MonoBehaviour
    {
        [SerializeField] private float _speed = 1.0f;
        private Inputs _inputs;
        private Rigidbody2D _rb2D;
        private Vector2 _moveInput;

        private void Awake()
        {
            _inputs = new Inputs();
            _rb2D = GetComponent<Rigidbody2D>();
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

        private void FixedUpdate()
        {
            //Reads the movement
            _moveInput = _inputs.Basket.Move.ReadValue<Vector2>();
           // Debug.Log("Movement: " + _moveInput);
            _moveInput.y = 0;
            _rb2D.velocity = _moveInput * _speed;
        }

    }
}
