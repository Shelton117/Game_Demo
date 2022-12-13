using UnityEngine;
using UnityEngine.UI;
using _2022_Season_3.New_Folder.Scripts.Utilities;

namespace _2022_Season_3.New_Folder.Scripts.UI
{
    public class Settlement : MonoBehaviour
    {
        [SerializeField] private Text win, fail;

        public void SetGameOverPanel(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Win:
                    win.gameObject.SetActive(true);
                    fail.gameObject.SetActive(false);
                    break;
                case GameState.Fail:
                    win.gameObject.SetActive(false);
                    fail.gameObject.SetActive(true);
                    break;
            }
        }

        public void OnRetryBtnClick()
        {
            
        }

        public void OnMuneBtnClick()
        {

        }
    }
}