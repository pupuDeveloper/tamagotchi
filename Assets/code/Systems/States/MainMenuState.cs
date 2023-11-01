namespace BunnyHole.States
{
    public class MainMenuState : GameStateBase
    {
        public override string SceneName { get { return "mainmenu"; } }
        public override StateType Type { get { return StateType.MainMenu; } }

        public MainMenuState() : base()
        {
            AddTargetState(StateType.MainScene);
            AddTargetState(StateType.Options);
            //AddTargetState(StateType.Credits);        
        }
    }
}
