using UnityEngine;
using _2022_Season_3.New_Folder.Scripts.Manager;

namespace _2022_Season_3.New_Folder.Scripts.command_mode
{
    public class MoveForward : Command
    {
        private GameObject mPlayer = GameManager.Instance.GetPlayer();

        public override void Execute()
        {
            mPlayer.transform.Translate(Vector3.forward * 10);
        }

        public override void Undo()
        {
            mPlayer.transform.Translate(Vector3.back);
        }
    }

    public class MoveBack : Command
    {
        private GameObject mPlayer = GameManager.Instance.GetPlayer();

        public override void Execute()
        {
            mPlayer.transform.Translate(Vector3.back * 10);
        }

        public override void Undo()
        {
            mPlayer.transform.Translate(Vector3.forward);
        }
    }

    public class MoveLeft : Command
    {
        private GameObject mPlayer = GameManager.Instance.GetPlayer();

        public override void Execute()
        {
            mPlayer.transform.Translate(Vector3.left * 10);
        }

        public override void Undo()
        {
            mPlayer.transform.Translate(Vector3.right);
        }
    }

    public class MoveRight : Command
    {
        private GameObject mPlayer = GameManager.Instance.GetPlayer();

        public override void Execute()
        {
            mPlayer.transform.Translate(Vector3.right * 10);
        }

        public override void Undo()
        {
            mPlayer.transform.Translate(Vector3.left);
        }
    }
}