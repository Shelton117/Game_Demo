using System.Collections.Specialized;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using _2022_Season_3.New_Folder.Scripts.Manager;
using _2022_Season_3.New_Folder.Scripts.Utilities;

namespace _2022_Season_3.New_Folder.Scripts.UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Text mCommandText;
        [SerializeField] private GameObject[] commands;
        [SerializeField] private GameObject commandItem;
        private List<ItemDrag> drags = new List<ItemDrag>();

        private void Start()
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

        private void OnEnable()
        {
            Utilities.EventHandler.UpdateCommandText += OnUpdateCommandText;
        }

        private void OnDisable()
        {
            Utilities.EventHandler.UpdateCommandText -= OnUpdateCommandText;
        }

        public void OnStartBtnClick()
        {
            StartCoroutine(CommandManager.Instance.StartPlay());

            var ID = string.Empty;
            foreach (var id in GameManager.Instance.ids)
            {
                ID += id.ToString();
            }

            mCommandText.text = ID;
        }

        private void OnUpdateCommandText(string obj)
        {
            mCommandText.text = obj;
        }
    }
}