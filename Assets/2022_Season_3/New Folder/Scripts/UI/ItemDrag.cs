using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using _2022_Season_3.New_Folder.Scripts.Manager;
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
            originalTransform = transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = false;

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
            var go = eventData.pointerCurrentRaycast.gameObject;
            if (go == null)
            {
                transform.position = originalTransform;
            }
            else
            {
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