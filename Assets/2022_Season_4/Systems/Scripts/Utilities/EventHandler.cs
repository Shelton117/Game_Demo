using System;
using Systems.Utilities;

namespace Systems.Utilities{
    /// <summary>
    /// ¨Æ¥ó¡]‰]²z¡^
    /// </summary>
    public static class EventHandler
    {
        #region ?´º¥[?¨Æ¥ó
        public static event Action BeforeSceneUnloadEvent;
        public static void CallBeforeSceneUnloadEvent(){
            BeforeSceneUnloadEvent?.Invoke();
        }

        public static event Action AfterSceneUnloadEvent;
        public static void CallAfterSceneUnloadEvent(){
            AfterSceneUnloadEvent?.Invoke();
        }
        #endregion

        #region ´å???‰Z§ó
        public static Action<GameState> GameStateChangeEvent;
        public static void CallGameStateChangeEvent(GameState gameState){
            GameStateChangeEvent?.Invoke(gameState);
        }
        #endregion
    }
}