using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using _2022_Season_3.New_Folder.Scripts.Manager;
using _2022_Season_3.New_Folder.Scripts.Utilities;
using EventHandler = _2022_Season_3.New_Folder.Scripts.Utilities.EventHandler;

namespace _2022_Season_3.New_Folder.Scripts.UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Text mCommandText;
        [SerializeField] private GameObject[] commands;
        [SerializeField] private GameObject commandItem;
        [SerializeField] private Settlement PanelGameOver;
        private List<ItemDrag> drags = new List<ItemDrag>();

        private void Start()
        {
            InitCommandItem();
        }

        private void OnEnable()
        {
            EventHandler.UpdateCommandText += OnUpdateCommandText;
            EventHandler.EndTheGame += OnEndTheGame;
        }

        private void OnDisable()
        {
            EventHandler.UpdateCommandText -= OnUpdateCommandText;
            EventHandler.EndTheGame -= OnEndTheGame;
        }

        private void OnUpdateCommandText(string obj)
        {
            mCommandText.text = obj;
        }
        
        private void OnEndTheGame(GameState obj)
        {
            PanelGameOver.gameObject.SetActive(true);
            PanelGameOver.SetGameOverPanel(obj);
        }

        private void InitCommandItem()
        {
            var datas = GameManager.Instance.ids;

            for (int i = 0; i < commands.Length; i++)
            {
                if (datas[i] != CommandID.None)
                {
                    var item = Instantiate(commandItem, commands[i].transform);
                    var drag = item.GetComponent<ItemDrag>();
                    drag.SetCommandID(datas[i]);
                    drags.Add(drag);
                }
            }
        }

        #region 按钮事件

        public void OnStartBtnClick()
        {
            StartCoroutine(CommandManager.Instance.StartPlay());
        }

        public void OnRestartBtnClick()
        {
            // 初始化关卡
        }
        
        #endregion

    }
}