using System.Collections.Generic;
using UnityEngine;
using _2022_Season_3.New_Folder.Scripts.Manager;
using _2022_Season_3.New_Folder.Scripts.Utilities;

namespace _2022_Season_3.New_Folder.Scripts.command_mode
{
    public class InputHandler : MonoBehaviour
    {
        private readonly MoveForward mMoveForward = new MoveForward();
        private readonly MoveBack mMoveBack = new MoveBack();
        private readonly MoveLeft mMoveLeft = new MoveLeft();
        private readonly MoveRight mMoveRight = new MoveRight();

        /// <summary>
        /// ת����
        /// </summary>
        private static Dictionary<CommandID, Command> dic = new Dictionary<CommandID, Command>()
        {
            {CommandID.Up, new MoveForward()},
            {CommandID.Down, new MoveBack()},
            {CommandID.Left, new MoveLeft()},
            {CommandID.Right, new MoveRight()},
            // TODO:����ָ��
        };
        
        private KeyCode[] mKeyCodes = new[]
        {
            KeyCode.W,
            KeyCode.A,
            KeyCode.S,
            KeyCode.D
        };// ��λ�Զ���ʱ�޸ĸ����鼴��

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            PlayerInputHandler();

            if (Input.GetKeyDown(KeyCode.B))
            {
                StartCoroutine(CommandManager.Instance.UndoStart());
            }
        }

        public static Command SetCommand(CommandID id)
        {
            return dic[id];
        }
        
        /// <summary>
        /// �������ָ��
        /// </summary>
        private void PlayerInputHandler()
        {
            if (Input.GetKeyDown(mKeyCodes[0]))
            {
                mMoveForward.Execute();
                CommandManager.Instance.AddCommands(mMoveForward);
                EventHandler.CallUpdateUIEvent(mKeyCodes[0].ToString());
            }

            if (Input.GetKeyDown(mKeyCodes[1]))
            {
                mMoveLeft.Execute();
                CommandManager.Instance.AddCommands(mMoveLeft);
                EventHandler.CallUpdateUIEvent(mKeyCodes[1].ToString());
            }

            if (Input.GetKeyDown(mKeyCodes[2]))
            {
                mMoveBack.Execute();
                CommandManager.Instance.AddCommands(mMoveBack);
                EventHandler.CallUpdateUIEvent(mKeyCodes[2].ToString());
            }

            if (Input.GetKeyDown(mKeyCodes[3]))
            {
                mMoveRight.Execute();
                CommandManager.Instance.AddCommands(mMoveRight);
                EventHandler.CallUpdateUIEvent(mKeyCodes[3].ToString());
            }
        }
    }

}
