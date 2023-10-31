namespace BunnyHole.States
{
    public class GameOverState : GameStateBase
    {
        public override string SceneName { get { return "GameOver"; } }
        public override StateType Type { get { return StateType.GameOver; } }

        public GameOverState() : base()
        {
            AddTargetState(StateType.MainMenu);
        }

    }
}