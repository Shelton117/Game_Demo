using System.Collections.Generic;
using Scripts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using _2022_Season_3.New_Folder.Scripts.Data;
using _2022_Season_3.New_Folder.Scripts.Utilities;

namespace _2022_Season_3.New_Folder.Scripts.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private SO_LevelData levelData;

        private SO_LevelData currentData;
        [HideInInspector] public List<CommandID> ids;
        [HideInInspector] public int times;

        [HideInInspector] public List<int> indexs = new List<int>();
        private GameObject mPlayer;

        public GameObject Player
        {
            get { return mPlayer; }
            set { mPlayer = value; }
        }

        // Start is called before the first frame update
        void Start()
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
            EventHandler.CallGameStateChangeEvent(GameState.Play);
            
            // 复制数据
            currentData = Instantiate(levelData);
            ids = currentData.commandID;
            times = currentData.times;

            // 获取缺失的命令
            for (int i = 0; i < currentData.commandID.Count; i++)
            {
                if (currentData.commandID[i] == CommandID.None)
                {
                    indexs.Add(i);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// 设置none位置的指令
        /// </summary>
        /// <param name="index"></param>
        /// <param name="id"></param>
        public void SetCommand(int index, CommandID id)
        {
            if (isIDInNone(index))
            {
                ids[index] = id;
                Debug.Log(id);
                indexs.Remove(index);
            }
            
            // 没none就可以执行play
            if (isReady())
            {
                EventHandler.CallReady2Play();
                Debug.Log("isReady");
            }
        }

        /// <summary>
        /// 判断是否为缺失的指令
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool isIDInNone(int index)
        {
            return indexs.Contains(index);
        }

        /// <summary>
        /// 是否准备就绪
        /// </summary>
        /// <returns></returns>
        private bool isReady()
        {
            return !ids.Contains(CommandID.None);
        }

        public void SetNone(int index)
        {
            if (!indexs.Contains(index) && index < ids.Count)
            {
                indexs.Add(index);
                ids[index] = CommandID.None;
            }
        }

        /// <summary>
        /// 进入关卡时获取玩家
        /// </summary>
        public void SetPlayer()
        {
            mPlayer = GameObject.Find("Player");
        }

        public GameObject GetPlayer()
        {
            return mPlayer;
        }
    }
}