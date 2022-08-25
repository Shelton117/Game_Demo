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

        public static event Action<string> UpdateCommandText;

        public static void CallUpdateUIEvent(string text)
        {
            UpdateCommandText?.Invoke(text);
        }
    }
}