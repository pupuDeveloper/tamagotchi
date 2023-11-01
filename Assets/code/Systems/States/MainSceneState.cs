namespace BunnyHole.States
{
    public class MainSceneState : GameStateBase
    {
        public override string SceneName { get { return "mainScene"; } }
        public override StateType Type { get { return StateType.MainScene; } }

        public MainSceneState() : base()
        {
            AddTargetState(StateType.GameOver);
            AddTargetState(StateType.Pause);
            AddTargetState(StateType.Minigame);
            AddTargetState(StateType.MainMenu);
            AddTargetState(StateType.Options);
            AddTargetState(StateType.MainScene);
        }
    }
}
