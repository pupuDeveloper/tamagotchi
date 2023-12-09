using UnityEngine;

namespace BunnyHole
{
    public class SpawnBerries : MonoBehaviour
    {
        private float _fallSpeed = 5.0f;
        private float _spinSpeed = 250.0f;
        
        private void FixedUpdate()
        {
            // Move the objects down
            transform.Translate(Vector3.down * _fallSpeed * Time.fixedDeltaTime, Space.World);
            transform.Rotate(Vector3.forward, _spinSpeed * Time.fixedDeltaTime);
        }
    }
}
