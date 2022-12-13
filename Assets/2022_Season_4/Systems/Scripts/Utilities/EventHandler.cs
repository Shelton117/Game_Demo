using System;
using Systems.Utilities;

namespace Systems.Utilities{
    /// <summary>
    /// �ƥ�]�]�z�^
    /// </summary>
    public static class EventHandler
    {
        #region ?���[?�ƥ�
        public static event Action BeforeSceneUnloadEvent;
        public static void CallBeforeSceneUnloadEvent(){
            BeforeSceneUnloadEvent?.Invoke();
        }

        public static event Action AfterSceneUnloadEvent;
        public static void CallAfterSceneUnloadEvent(){
            AfterSceneUnloadEvent?.Invoke();
        }
        #endregion

        #region ��???�Z��
        public static Action<GameState> GameStateChangeEvent;
        public static void CallGameStateChangeEvent(GameState gameState){
            GameStateChangeEvent?.Invoke(gameState);
        }
        #endregion
    }
}