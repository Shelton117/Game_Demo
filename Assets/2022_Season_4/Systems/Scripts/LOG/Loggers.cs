using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Systems.Logger
{

    /// <summary>
    /// 二次封装官方的log方法，新增本地log文件读写
    /// </summary>
    public static class Loggers
    {
        public static bool LogEnable = false;
        // public static bool LogEnable = true;
        // public static bool LogEnable = true;

        [MenuItem("Loggers/LogEnable")]
        static void ToggleLog()
        {
            LogEnable = !LogEnable;
            Loggers.Log("Log:" + LogEnable);
            Menu.SetChecked("Loggers/LogEnable", LogEnable);
        }

        #region log

        public static void Log(object message, Object context = null)
        {
            if (LogEnable)
            {
                Debug.Log(message, context);
            }
        }

        public static void LogList<T>(List<T> message)
        {
            string msg = "";
            foreach (var item in message)
            {
                msg += item + "\n";
            }
            Debug.Log(msg);
        }

        public static void LogDictionary<T,K>(Dictionary<T,K> message)
        {
            string msg = "";
            foreach (var item in message)
            {
                msg += item.Key + " " + item.Value + "\n";
            }
            Debug.Log(msg);
        }

        public static void LogError(object message)
        {
            Debug.LogError(message);
        }

        public static void LogWarning(object message)
        {
            Debug.LogWarning(message);
        }

        #endregion
    }
}