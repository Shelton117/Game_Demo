using System.Text;
using System.IO;
using UnityEngine;
using Scripts.Utilities;

namespace Systems.Logger{
    public class LoggerManager : Singleton<LoggerManager>
    {
        // 优化字符串的重复构造
        StringBuilder logStr = new StringBuilder();
        // 日志目录
        string logSavePath;

        // Start is called before the first frame update
        void Start()
        {
            var t = System.DateTime.Now.ToString("yyyyMMddhhmmss");
            logSavePath = string.Format("{0}/output_{1}.log", Application.persistentDataPath, t);
            // Application.logMessageReceived += OnLogCallBack;
        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        void OnEnable()
        {
            // Application.logMessageReceived += OnLogCallBack;
        }

        /// <summary>
        /// This function is called when the behaviour becomes disabled or inactive.
        /// </summary>
        void OnDisable()
        {
            Application.logMessageReceived -= OnLogCallBack;
        }

        /// <summary>
        /// 生成日志调用回调事件
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="stackTrace"></param>
        /// <param name="type"></param>
        private void OnLogCallBack(string condition, string stackTrace, LogType type){
            logStr.Append(condition);
            logStr.Append("\n");
            logStr.Append(stackTrace);
            logStr.Append("\n");

            if(logStr.Length <= 0)return;

            if (!File.Exists(logSavePath))
            {
                var fs = File.Create(logSavePath);
                fs.Close();
            }

            using (var sw = File.AppendText(logSavePath))
            {
                sw.WriteLine(logStr.ToString());
            }
            logStr.Remove(0,logStr.Length);
        }
    }
}