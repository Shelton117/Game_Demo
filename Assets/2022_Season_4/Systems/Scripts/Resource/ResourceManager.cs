using System.IO;
using System.Collections;
using System.Collections.Generic;
using Scripts.Utilities;
using UnityEngine;
using UnityEditor;
using Systems.Logger;

namespace Systems.Resource{
    public class ResourceManager : Singleton<ResourceManager>
    {
        private AssetBundle AB;
        Dictionary<string, AssetBundle> abPool = new Dictionary<string, AssetBundle>();

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            // 加载ab包
            InitABPool();
        }

        private void InitABPool(){
            string PATH = Application.streamingAssetsPath + "/";

            if (Directory.Exists(PATH))
            {
                DirectoryInfo dInfo = new DirectoryInfo(PATH);
                FileInfo[] files = dInfo.GetFiles("*",SearchOption.AllDirectories);

                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Name.EndsWith(".meta") || files[i].Name.EndsWith(".manifest"))
                    {
                        continue;
                    }
                    Loggers.Log("加载：" + files[i].Name);

                    var ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + files[i].Name);
                    if (!abPool.ContainsKey(files[i].Name))
                    {
                        abPool.Add(files[i].Name, ab);
                    }

                    // TODO:可视化资源目录
                }
            }

            Loggers.Log("加载完毕");
        }

        /// <summary>
        /// Resources加载
        /// </summary>
        /// <param name="objPath"></param>
        /// <returns></returns>
        public GameObject AddObj2Scence(string objPath)
        {
            var obj = Resources.Load(objPath);
            if (obj != null)
            {
                // GameObject instance = Instantiate(obj) as GameObject;
                // 带依赖关系的方法
                GameObject instance = PrefabUtility.InstantiatePrefab(obj) as GameObject;
                // TODO:资源记录

                return instance;
            }
            else
            {
                Debug.LogError("路径错误：" + objPath);
            }

            return null;
        }

        // public T LoadRes<T>(string resPath) where T:Object{
        //     T t = Resources.Load<T>(resPath);
        //     return t;
        // }

        /// <summary>
        /// ab包加载
        /// </summary>
        /// <param name="abPath">ab包路径</param>
        /// <param name="assetName">资源名</param>
        /// <returns></returns>
        public GameObject AddObj2ScenceByAssetBundle(string assetName){
            if (AB == null)
            {
                Debug.LogError("ab包路径错误");
            }
            else
            {
                var obj = AB.LoadAsset(assetName);
                if (obj != null)
                {
                    GameObject instance = Instantiate(obj) as GameObject;

                    return instance;
                }
                else
                {
                    Debug.LogError("未找到该资源：" + assetName);
                }
            }

            return null;
        }

        public T AddObj2ScenceByAssetBundle<T>(string assetName, string abPath) where T:Object{
            if (abPool.ContainsKey(abPath))
            {
                var obj = abPool[abPath].LoadAsset(assetName);
                if (obj != null)
                {
                    // T instance = PrefabUtility.InstantiatePrefab(obj) as T;
                    T instance = Instantiate(obj) as T;

                    return instance;
                }
                else
                {
                    Debug.LogError("未找到该资源：" + assetName);
                }
            }
            else
            {
                Debug.LogError("ab包路径错误:" + abPath);
            }

            return null;
        }

        /// <summary>
        /// 异步加载
        /// </summary>
        /// <param name="abPath"></param>
        /// <param name="objName"></param>
        /// <returns></returns>
        public void AddObj2ScenceAsync(string abPath, string objName){
            StartCoroutine(LoadABRes(abPath, objName));
            AssetBundle.UnloadAllAssetBundles(false);
        }

        private IEnumerator LoadABRes(string abPath, string objName){
            AssetBundleCreateRequest abcr = AssetBundle.LoadFromFileAsync(Application.streamingAssetsPath + "/" + abPath);
            yield return abcr;

            AssetBundleRequest abr = abcr.assetBundle.LoadAssetAsync(objName,typeof(GameObject));
            yield return abr;

            GameObject go = Instantiate(abr.asset) as GameObject;
            go.transform.position = Vector3.zero;
        }


        // 卸载
        public GameObject MoveObjFromScence(string objName)
        {
            GameObject obj = null;
            if (objPool.ContainsKey(objName))
            {
                obj = objPool[objName];
                Destroy(obj);
                objPool.Remove(objName);
            }

            return obj;
        }

        #region  单独用个类管理

        Dictionary<string, GameObject> objPool = new Dictionary<string, GameObject>();

        private void AddObjPool(string objName, GameObject go){
            if (!objPool.ContainsKey(objName))
                {
                    objPool.Add(objName, go);
                    Loggers.Log("pool加载完毕");
                }
                else
                {
                    Loggers.LogError(objName + "已存在");
                }
        }

        private void RemoveObjPool(string objName){
            if (!objPool.ContainsKey(objName))
                {
                    objPool.Remove(objName);
                    Loggers.Log("pool清楚完毕");
                }
                else
                {
                    Loggers.LogError(objName + "已存在");
                }
        }

        private void RemoveAllObjPool(){
            if (objPool != null)
                {
                    objPool.Clear();
                }
        }

        #endregion
    }

}
