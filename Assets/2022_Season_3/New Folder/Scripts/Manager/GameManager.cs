using System.Collections.Generic;
using Scripts.Utilities;
using UnityEngine;
using _2022_Season_3.New_Folder.Scripts.Data;
using _2022_Season_3.New_Folder.Scripts.Utilities;

namespace _2022_Season_3.New_Folder.Scripts.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private SO_LevelData levelData;
        [HideInInspector] public List<CommandID> ids;
        [HideInInspector] public List<int> indexs = new List<int>();

        // Start is called before the first frame update
        void Start()
        {
            ids = levelData.commandID;

            // 获取缺失的命令
            for (int i = 0; i < levelData.commandID.Count; i++)
            {
                if (levelData.commandID[i] == CommandID.None)
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
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="id"></param>
        public void SetCommand(int index, CommandID id)
        {
            if (isIDInNone(index))
            {
                ids[index] = id;
                indexs.Remove(index);
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

        public void SetNone(int index)
        {
            if (!indexs.Contains(index) && index < ids.Count)
            {
                indexs.Add(index);
                ids[index] = CommandID.None;
            }
        }
    }
}