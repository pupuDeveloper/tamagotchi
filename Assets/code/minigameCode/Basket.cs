using UnityEngine;

namespace BunnyHole
{
    public class Basket : MonoBehaviour
    {
        [SerializeField] private float _speed = 1.0f; // Basket's speed
        [SerializeField] private GameObject popoutwindow; // Popout window that shows up first
        [SerializeField] private ParticleSystem successParticles; // Particle effect for strawberry collection
        [SerializeField] private ParticleSystem eyeballParticles; // Particle effect for when the eye is collected
        [SerializeField] private Sprite[] spriteArray; // Basket damaged sprite array
        private Vector3 _mousePos; // Mouse position in Vector3
        private Rigidbody2D _rb2D; // Ridigbody 2D
        private Vector2 _position; 
        private AudioSource _openAudio; //Strawberry open audio effect

        public SpriteRenderer spriteRenderer; // Renders the basket damaged sprites.

        private void Awake()
        {
            // Getting Rigidbody2D and Audio Source components from the basket.
            _rb2D = GetComponent<Rigidbody2D>();
            _openAudio = GetComponent<AudioSource>();
        }

        private void FixedUpdate()
        {
            // If info window is not open, we can move the basket.
            if (popoutwindow.activeSelf == false)
            {
                _mousePos = Input.mousePosition;
                _mousePos = Camera.main.ScreenToWorldPoint(_mousePos);
                _mousePos.z = 0;
                // y-axis placement in the game.
                _mousePos.y = -4.26f;
                _position = Vector2.Lerp(_mousePos, _mousePos, _speed);
                _rb2D.MovePosition(_position);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Are strawberries colliding with the basket? If yes, destroy
            // the strawberry
            if (collision.gameObject.layer == LayerMask.NameToLayer("Strawberry"))
            {
                // Play strawberry pickup audio.
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
                // Play basket damaged audio.
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
