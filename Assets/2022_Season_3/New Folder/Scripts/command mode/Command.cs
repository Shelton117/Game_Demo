using UnityEngine;

namespace _2022_Season_3.New_Folder.Scripts.command_mode
{
    public abstract class Command
    {
        public abstract void Execute();
        public abstract void Undo();
    }
}