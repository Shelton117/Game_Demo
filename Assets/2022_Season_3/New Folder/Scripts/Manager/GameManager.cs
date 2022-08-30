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
        private SO_LevelData currentData;
        [HideInInspector] public List<CommandID> ids;
        [HideInInspector] public List<int> indexs = new List<int>();
        private GameObject mPlayer;

        // Start is called before the first frame update
        void Start()
        {
            mPlayer = GameObject.Find("Player");
            // ��������
            currentData = Instantiate(levelData);
            ids = currentData.commandID;

            // ��ȡȱʧ������
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
        /// 
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
            
            // ûnone�Ϳ���ִ��play
            if (isReady())
            {
                EventHandler.CallReady2Play();
                Debug.Log("isReady");
            }
        }

        /// <summary>
        /// �ж��Ƿ�Ϊȱʧ��ָ��
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool isIDInNone(int index)
        {
            return indexs.Contains(index);
        }

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

        public GameObject GetPlayer()
        {
            return mPlayer;
        }
    }
}