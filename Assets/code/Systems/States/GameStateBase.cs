using System.Collections.Generic;
using UnityEngine.SceneManagement; // Level loading stuff

namespace BunnyHole.States
{
    public abstract class GameStateBase
    {
        // The list of all possible target states
        private List<StateType> _targetState = new List<StateType>();

        // An abstract property means that it has to be
        // defined in a child class.
        public abstract string SceneName { get; }
        public abstract StateType Type { get; }
        // By default, a state is not additive (returns false).
        // This behaviour can be changed in a child class.
        public virtual bool IsAdditive { get { return false; } }

        protected GameStateBase()
        {
        }

        protected void AddTargetState(StateType stateType)
        {
            // If the state is already in the list, do nothing
            if (!_targetState.Contains(stateType))
            {
                // Add the state to the list
                _targetState.Add(stateType);
            }
        }

        protected void RemoveTargetState(StateType stateType)
        {
            _targetState.Remove(stateType);
        }

        //Activates the state. Load associated scene by default.
        // The loading of the scene is forced even if the scene
        // is already loaded.
        public virtual void Activate(bool forceLoad = false)
        {
            // The currently active scene.
            Scene currentScene = SceneManager.GetActiveScene();
            if (forceLoad || currentScene.name.ToLower() != SceneName.ToLower())
            {
                // if (IsAdditive) {
                //  loadMode = LoadSceneMode.Additive;
                // }else {
                //  loadMode = LoadSceneMode.Single;
                // }
                LoadSceneMode loadMode = IsAdditive
                ? LoadSceneMode.Additive
                : LoadSceneMode.Single;

                SceneManager.LoadSceneAsync(SceneName, loadMode);
            }
        }

        public virtual void Deactivate()
        {
            // Unload the level if necessary.
            if (IsAdditive)
            {
                SceneManager.UnloadSceneAsync(SceneName);
            }
        }

        public bool IsValidTarget(StateType targetStateType)
        {
            return _targetState.Contains(targetStateType);
        }
    }
}