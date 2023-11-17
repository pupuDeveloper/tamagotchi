namespace BunnyHole.States
{
	public class IntroState : GameStateBase
	{
		public override string SceneName { get { return "Intro"; } }
		public override StateType Type { get { return StateType.Intro; } }

		public IntroState()
		{
			AddTargetState(StateType.MainMenu);
		}
	}
}
