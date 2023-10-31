namespace BunnyHole.States
{
    public class CreditsState : GameStateBase
    {
        public override StateType Type { get { return StateType.Credits; } }
        public override string SceneName { get { return "Credits"; } }
        public override bool IsAdditive { get { return true; } }

        public CreditsState()
        {
            AddTargetState(StateType.MainMenu);
        }
    }
}