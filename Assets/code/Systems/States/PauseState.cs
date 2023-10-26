using UnityEngine;

namespace BunnyHole.States
{
    public class PauseState : GameStateBase
    {
        public override StateType Type { get { return StateType.Pause; } }
        public override string SceneName { get { return "Options"; } }
        public override bool IsAdditive { get { return true; } }

        public PauseState()
        {
            AddTargetState(StateType.MainScene);
            AddTargetState(StateType.MainMenu);
        }

        public override void Activate(bool forceLoad = false)
        {
            base.Activate(forceLoad);
            
            // Pauses the time
            Time.timeScale = 0;
        }

        public override void Deactivate()
        {
            base.Deactivate();

            // Resumes the time
            Time.timeScale = 1;
        }
    }
}
