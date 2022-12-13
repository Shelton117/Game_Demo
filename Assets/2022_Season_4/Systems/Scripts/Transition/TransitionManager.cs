using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using Scripts.Utilities;
using UnityEngine.SceneManagement;
using Systems.Utilities;
using UnityEngine;
using Systems.Logger;

namespace Systems.Transition
{
    public class TransitionManager : Singleton<TransitionManager>
    {
        bool canTtransition;
        Scene newScene;
        Dictionary<string, Scene> sceneDic = new Dictionary<string, Scene>();
        string firstSceneName;

        #region Cycle
        // Start is called before the first frame update
        void Start()
        {
            firstSceneName = SceneManager.GetActiveScene().name;
            sceneDic.Add(SceneManager.GetActiveScene().name, SceneManager.GetActiveScene());

            Loggers.Log("初始化场景完毕:" + firstSceneName);
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

        }

        /// <summary>
        /// This function is called when the behaviour becomes disabled or inactive.
        /// </summary>
        void OnDisable()
        {

        }
        #endregion

        /// <summary>
        /// 切换场景
        /// </summary>
        /// <param name="from">卸载场景</param>
        /// <param name="to">加载场景</param>
        /// <returns></returns>
        private IEnumerator Transition2Scene(string from, string to){
            if (from != string.Empty && sceneDic.ContainsKey(from))
            {
                // 卸载场景
                EventHandler.CallBeforeSceneUnloadEvent();
                sceneDic.Remove(from);
                yield return SceneManager.UnloadSceneAsync(from);
            }

            if (to == string.Empty)
            {

            }
            else if(!sceneDic.ContainsKey(to))
            {
                // 加载场景
                yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);
                // 激活加载场景
                newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
                sceneDic.Add(to, newScene);
                Loggers.LogDictionary(sceneDic);
                SceneManager.SetActiveScene(newScene);
                EventHandler.CallAfterSceneUnloadEvent();
            }
            else
            {
                Debug.LogError(to + "场景已存在");
            }
        }

        public Scene AddScene(string sceneName){
            StartCoroutine(Transition2Scene(string.Empty, sceneName));
            return sceneDic[sceneName];
        }

        public void RemoveScene(string sceneName){
            StartCoroutine(Transition2Scene(sceneName, string.Empty));
        }

        public void Transition(string from, string to){
            //if (canTtransition)
            {
                StartCoroutine(Transition2Scene(from, to));
            }
        }

        public void ActiveScene(string sceneName){
            if (sceneDic.ContainsKey(sceneName))
            {
                SceneManager.SetActiveScene(sceneDic[sceneName]);
                // return sceneDic[sceneName];
            }

            Debug.LogError(sceneName + "场景不存在！");
        }

        public void ClearScene(){
            List<string> sceneNameLst = sceneDic.Keys.ToList();
            foreach (var sceneName in sceneNameLst)
            {
                if (sceneName != firstSceneName)
                {
                    RemoveScene(sceneName);

                    sceneDic.Remove(sceneName);
                }
            }
        }
    }
}