using GA.BunnyHole.Generated;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BunnyHole
{
public class LevelManager : MonoBehaviour
{
        private Inputs _inputs;

        private void Awake()
        {
            _inputs = new Inputs();
        }

        private void OnEnable()
        {
            _inputs.Systems.Enable();
        }

        private void OnDisable()
        {
            _inputs.Systems.Disable();
        }

        private void Update()
        {
            if(_inputs.Systems.Pause.WasPressedThisFrame())
            {
                GameManager.Instance.Go(States.StateType.Pause);
            }
        }
    }
}
