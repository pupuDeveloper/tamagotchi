namespace BunnyHole.States
{
    public class GraveyardState : GameStateBase
    {
        public override StateType Type { get { return StateType.Graveyard; } }
        public override string SceneName { get { return "graveyard"; } }
        public override bool IsAdditive { get { return true; } }

        public GraveyardState()
        {
            AddTargetState(StateType.MainMenu);
        }
    }
}