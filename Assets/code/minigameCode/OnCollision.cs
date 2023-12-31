using UnityEngine;

namespace BunnyHole
{
    public class Collision : MonoBehaviour
    {
        /// <summary>
        /// New position for the spawned berries and eyeballs.
        /// </summary>
        private Vector3 _newPos;

        /// <summary>
        /// On triggered collider we go here (the floor, in the floor layer)
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Is the collision happening with the floor? If yes..
            if (collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
            {
                // Setting the new random x-axis position between -3.85 and 3.80
                float _xPos = Random.Range(-3.85f, 3.80f);
                // Setting the new position for the berries and eyeballs:
                // random range x-axis, y-axis is at 6 and z 0.
                _newPos = new Vector3(_xPos, 6, 0);
                // transforming the berries and eyeballs to new position.
                transform.position = _newPos;
            }
            // Is collision happening with the eyeball do the same thing.
            if (collision.gameObject.layer == LayerMask.NameToLayer("Eyeball"))
            {
                float _xPos = Random.Range(-3.85f, 3.80f);
                _newPos = new Vector3(_xPos, 6, 0);
                transform.position = _newPos;
            }
        }
    }
}
