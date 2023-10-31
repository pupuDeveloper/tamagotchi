namespace BunnyHole.States
{
    public class OptionsState : GameStateBase
    {
        public override StateType Type { get { return StateType.Options; } }
        public override string SceneName { get { return "Options"; } }
        public override bool IsAdditive { get { return true; } }

        public OptionsState()
        {
            AddTargetState(StateType.MainMenu);
        }
    }
}
