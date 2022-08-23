using System.Collections;
using System.Collections.Generic;
using Scripts.Utilities;
using UnityEngine;
using _2022_Season_3.New_Folder.Scripts.command_mode;

namespace _2022_Season_3.New_Folder.Scripts.Manager
{
    public class CommandManager : Singleton<CommandManager>
    {
        private readonly List<Command> mCommands = new List<Command>();

        void Start()
        {
            gameObject.AddComponent<InputHandler>();
        }

        public void AddCommands(Command command)
        {
            mCommands.Add(command);
        }

        public IEnumerator StartPlay()
        {
            foreach (var command in mCommands)
            {
                yield return new WaitForSeconds(0.2f);
                command.Undo();
            }
        }

        public IEnumerator UndoStart()
        {
            mCommands.Reverse();

            foreach (var command in mCommands)
            {
                yield return new WaitForSeconds(0.2f);
                command.Undo();
            }

            mCommands.Clear();
        }
    }
}