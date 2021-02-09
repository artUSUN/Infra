using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Code.Task_1.Systems
{
    public static class GameStatesSwitcher
    {
        public enum GameStates
        {
            PreGame,
            Game,
            GameEnded
        }

        private static bool initialized = false;

        public static GameStates CurrentState { get; private set; }
        public static Faction BlueFaction { get; private set; }
        public static Faction RedFaction { get; private set; }
        public static Faction WinningFaction { get; private set; }

        public static event Action GameStarted;
        public static event Action GameEnded;

        public static void Initialize(Faction blue, Faction red)
        {
            if (initialized)
            {
                Debug.LogError("GameStatesSwitcher already initialized");
                return;
            }

            BlueFaction = blue;
            RedFaction = red;
            CurrentState = GameStates.PreGame;
            initialized = true;
            SceneManager.activeSceneChanged += OnSceneLoaded;
        }

        public static void FactionLost(Faction losingFaction)
        {
            if (CurrentState != GameStates.Game) return;

            WinningFaction = losingFaction == RedFaction ? BlueFaction : RedFaction;
            CurrentState = GameStates.GameEnded;
            GameEnded?.Invoke();
        }

        public static void StartGame()
        {
            if (CurrentState != GameStates.PreGame) return;

            ActivateTroopers(RedFaction);
            ActivateTroopers(BlueFaction);
            CurrentState = GameStates.Game;
            GameStarted?.Invoke();
        }

        private static void OnSceneLoaded(Scene current, Scene next)
        {
            initialized = false;
            SceneManager.activeSceneChanged -= OnSceneLoaded;
        }

        private static void ActivateTroopers(Faction faction)
        {
            faction.ForEachTrooper(trooper => trooper.SetState(trooper.TrooperStates.MoveToTarget));
        }
    }
}