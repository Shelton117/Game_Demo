using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using _2022_Season_3.New_Folder.Scripts.Manager;
using _2022_Season_3.New_Folder.Scripts.Transition;
using _2022_Season_3.New_Folder.Scripts.Utilities;

namespace _2022_Season_3.New_Folder.Scripts.UI
{
    public class ItemDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        /// <summary>
        /// 初始位置
        /// </summary>
        private Vector3 originalTransform;
        private Text mName;

        private int index = -1;
        /// <summary>
        /// 当前块的指令
        /// </summary>
        [SerializeField] private CommandID id = CommandID.None;

        private void Start()
        {
            SetIDName();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            // 记录原先的位置
            originalTransform = transform.position;

            GetComponent<CanvasGroup>().blocksRaycasts = false;

            // 初始化?
            // TODO：建议删除/转移
            if (index > -1)
            {
                GameManager.Instance.SetNone(index);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            this.transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            // TODO:复制一份
            if (this.transform.parent.childCount == 0)
            {
                var ob = Instantiate(this);
                ob.transform.SetParent(this.transform.parent);
                ob.transform.position = originalTransform;
            }

            var go = eventData.pointerCurrentRaycast.gameObject;
            if (go == null)
            {
                transform.position = originalTransform;
            }
            else
            {
                switch (id)
                {
                    case CommandID.Start:
                        if (go.name == "GameNameImg")
                        {
                            Debug.Log("Start");
                            transform.SetParent(go.transform);
                            transform.position = go.transform.position;

                            TransitionManager.Instance.Transition("Menu", "L0_1");
                        }
                        else
                        {
                            transform.position = originalTransform;
                        }
                        break;
                    case CommandID.Setting:
                        if (go.name != "GameNameImg")
                        {
                            Debug.Log("Setting");
                            transform.position = originalTransform;
                        }
                        break;
                    case CommandID.Exit:
                        if (go.name == "GameNameImg")
                        {
                            Debug.Log("Exit");
                            transform.SetParent(go.transform);
                            transform.position = go.transform.position;

                            Application.Quit();
                        }
                        break;
                    default:
                        if (go.tag == "CommandBG" && GameManager.Instance.isIDInNone(int.Parse(go.name)))
                        {
                            transform.SetParent(go.transform);
                            transform.position = go.transform.position;

                            index = int.Parse(go.name);
                            if (index > -1)
                            {
                                GameManager.Instance.SetCommand(index, id);
                            }
                        }
                        else
                        {
                            transform.position = originalTransform;
                        }
                        break;
                }
            }

            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

        public void SetCommandID(CommandID ID)
        {
            id = ID;
            SetIDName();
        }

        private void SetIDName()
        {
            mName = GetComponentInChildren<Text>();
            mName.text = id.ToString();
        }
    }
}