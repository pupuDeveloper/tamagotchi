using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GA.BunnyHole.Generated;

namespace BunnyHole
{
    public class Basket : MonoBehaviour
    {
        [SerializeField] private float _speed = 1.0f;
        [SerializeField] private GameObject popoutwindow;
        [SerializeField] private ParticleSystem successParticles;
        [SerializeField] private ParticleSystem eyeballParticles;
        [SerializeField] private Sprite[] spriteArray;
        private Inputs _inputs;
        private Rigidbody2D _rb2D;
        private Vector2 _moveInput;
        //Strawberry open audio effect
        private AudioSource _openAudio;

        public SpriteRenderer spriteRenderer;

        private void Awake()
        {
            _inputs = new Inputs();
            _rb2D = GetComponent<Rigidbody2D>();
            _openAudio = GetComponent<AudioSource>();
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
            if (popoutwindow.activeSelf == false)
            {
                //Reads the movement
                _moveInput = _inputs.Basket.Move.ReadValue<Vector2>();
                // Debug.Log("Movement: " + _moveInput);
                _moveInput.y = 0;
                _rb2D.velocity = _moveInput * _speed;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Are strawberries colliding with the basket? If yes, destroy
            // the strawberry
            if (collision.gameObject.layer == LayerMask.NameToLayer("Strawberry"))
            {
                // Play audio
                if (_openAudio != null)
                {
                    AudioManager.PlayClip(_openAudio, Config.SoundEffect.Strawberry);
                }
                Destroy(collision.gameObject);
                Debug.Log("Correct");
                Counting._count++;
                Debug.Log(Counting._count);
                successParticles.Play();
            }

            if (collision.gameObject.layer == LayerMask.NameToLayer("Eyeball"))
            {
                if (_openAudio != null)
                {
                    AudioManager.PlayClip(_openAudio, Config.SoundEffect.BasketDamaged);
                }
                Destroy(collision.gameObject);
                Debug.Log("wrong");
                Counting.eyeBallCount++;
                Debug.Log(Counting.eyeBallCount);
                eyeballParticles.Play();
                spriteRenderer.sprite = spriteArray[Counting.eyeBallCount];
            }
        }
    }
}
