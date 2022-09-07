using UnityEngine;
using _2022_Season_3.New_Folder.Scripts.Manager;
using _2022_Season_3.New_Folder.Scripts.Utilities;

namespace _2022_Season_3.New_Folder.Scripts
{
    public class ColliderCheck : MonoBehaviour
    {
        [SerializeField] private GameState Check_Type;
        private bool EndOfOneRound = false;

        void OnEnable()
        {
            EventHandler.EndOfOneRound += OnEndOfOneRound;
        }

        void OnDisable()
        {
            EventHandler.EndOfOneRound -= OnEndOfOneRound;
        }

        void OnTriggerEnter(Collider other)
        {
            if (CommandManager.Instance.Time2Zero())
            {
                if (other.gameObject.tag == "Player")
                {
                    Debug.Log("win");

                    CommandManager.Instance.EndGame();

                    EventHandler.CallEndTheGame(Check_Type);
                }
            }
            
        }

        void OnTriggerStay(Collider other)
        {
            
        }

        private void OnEndOfOneRound()
        {
            EndOfOneRound = true;
        }
    }
}