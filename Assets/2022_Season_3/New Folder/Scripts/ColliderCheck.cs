using UnityEngine;
using _2022_Season_3.New_Folder.Scripts.Manager;
using _2022_Season_3.New_Folder.Scripts.Utilities;

namespace _2022_Season_3.New_Folder.Scripts
{
    public class ColliderCheck : MonoBehaviour
    {
        [SerializeField] private GameState Check_Type;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("win");
                
                CommandManager.Instance.EndGame();

                EventHandler.CallEndTheGame(Check_Type);
            }
        }
    }
}