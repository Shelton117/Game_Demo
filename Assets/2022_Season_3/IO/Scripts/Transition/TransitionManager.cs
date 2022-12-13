using System.Collections;
using Scripts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using _2022_Season_3.New_Folder.Scripts.Utilities;

namespace _2022_Season_3.New_Folder.Scripts.Transition
{
    /// <summary>
    /// ������������ص�MG
    /// </summary>
    public class TransitionManager : Singleton<TransitionManager>
    {
        [Tooltip("��������")]
        public string startScene;
        /// <summary>
        /// ���뵭�����壨��ɫpanel���֣�
        /// </summary>
        [SerializeField] private CanvasGroup fadeCanvasGroup;
        /// <summary>
        /// ���뵭������ʱ��
        /// </summary>
        [SerializeField] private float fadeDuration;
        /// <summary>
        /// ��ɫ���������֣�
        /// </summary>
        private bool isFade;
        /// <summary>
        /// �Ƿ������ת����
        /// </summary>
        private bool canTtransition;

        /// <summary>
        /// ��ʼʱ���صĳ���
        /// </summary>
        private void Start()
        {
            // TODO����������
        }

        private void OnEnable()
        {
            EventHandler.GameStateChangeEvent += OnGameStateChangeEvent;
            EventHandler.StartNewGameEvent += OnStartNewGameEvent;
        }

        private void OnDisable()
        {
            EventHandler.GameStateChangeEvent -= OnGameStateChangeEvent;
            EventHandler.StartNewGameEvent -= OnStartNewGameEvent;
        }

        private void OnGameStateChangeEvent(GameState gameState)
        {
            canTtransition = gameState == GameState.Play;
        }

        private void OnStartNewGameEvent(int gameWeek)
        {
            StartCoroutine(Transition2Scene("Menu", startScene));
        }

        /// <summary>
        /// �ⲿ���ü��س����ķ���
        /// </summary>
        /// <param name="from">������</param>
        /// <param name="to">����ȥ</param>
        public void Transition(string from, string to)
        {
            if (!isFade && canTtransition)
            {
                StartCoroutine(Transition2Scene(from, to));
            }
        }

        /// <summary>
        /// �任����
        /// </summary>
        /// <param name="from">���ĸ�������</param>
        /// <param name="to">���ĸ�����ȥ</param>
        /// <returns></returns>
        private IEnumerator Transition2Scene(string from, string to)
        {
            yield return Fade(1);

            if (from != string.Empty)
            {
                //EventHandler.CallBeforeSceneUnloadEvent();
                yield return SceneManager.UnloadSceneAsync(from);
            }

            yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);

            // �ҵ��¼��صĳ�����������UIʱ��
            // TODO���Ż�������ȡ
            Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
            SceneManager.SetActiveScene(newScene);
            //EventHandler.CallAfterSceneUnloadEvent();
            yield return Fade(0);
        }

        /// <summary>
        /// ���뵭��Ч��
        /// </summary>
        /// <param name="targetAlpha">����panel�İ�����ֵ</param>
        /// <returns></returns>
        private IEnumerator Fade(float targetAlpha)
        {
            isFade = true;
            fadeCanvasGroup.blocksRaycasts = true;

            float speed = Mathf.Abs(fadeCanvasGroup.alpha - fadeDuration) / fadeDuration;
            while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
            {
                fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
                yield return null;
            }

            fadeCanvasGroup.blocksRaycasts = false;
            isFade = false;
        }
    }

}