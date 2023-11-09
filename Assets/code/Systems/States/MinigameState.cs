namespace BunnyHole.States
{
    public class MinigameState : GameStateBase
    {
        public override string SceneName { get { return "Minigame"; } }
        public override StateType Type { get { return StateType.Minigame; } }

        public MinigameState() : base()
        {
            AddTargetState(StateType.MainScene);        }
    }
}
