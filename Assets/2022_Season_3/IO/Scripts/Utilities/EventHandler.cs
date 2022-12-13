using System;

namespace _2022_Season_3.New_Folder.Scripts.Utilities
{
    public class EventHandler
    {
        public static event Action Ready2Play;
        public static void CallReady2Play()
        {
            Ready2Play?.Invoke();
        }

        public static event Action EndOfOneRound;
        public static void CallEndOfOneRound()
        {
            EndOfOneRound?.Invoke();
        }

        public static event Action<GameState> EndTheGame;
        public static void CallEndTheGame(GameState gameState)
        {
            EndTheGame?.Invoke(gameState);
        }

        public static event Action<string> UpdateCommandText;
        public static void CallUpdateUIEvent(string text)
        {
            UpdateCommandText?.Invoke(text);
        }

        public static Action<GameState> GameStateChangeEvent;
        public static void CallGameStateChangeEvent(GameState gameState)
        {
            GameStateChangeEvent?.Invoke(gameState);
        }

        public static event Action<int> StartNewGameEvent;
        public static void CallStartNewGameEvent(int gameWeek)
        {
            StartNewGameEvent?.Invoke(gameWeek);
        }
    }
}