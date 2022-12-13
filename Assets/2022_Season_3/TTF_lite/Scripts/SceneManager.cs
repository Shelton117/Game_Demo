using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scripts.Utilities;

namespace TTF_lite
{
    public class SceneManager : Singleton<SceneManager>
    {
        [SerializeField]
        private GameObject _new;
        [SerializeField]
        private GameObject _old;

        private Vector3 pos_new, pos_old;
        [SerializeField]
        private bool isChange = false;

        // Start is called before the first frame update
        void Start()
        {
            pos_new = _new.transform.position;
            pos_old = _old.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                ChangeScene();
            }
        }

        [ExecuteInEditMode]
        [ContextMenu("Play")]
        public void ChangeScene()
        {
            if (isChange)
            {
                _new.transform.position = pos_old;
                _old.transform.position = pos_new;
            }
            else
            {
                _new.transform.position = pos_new;
                _old.transform.position = pos_old;
            }

            isChange = !isChange;
        }
    }

    // [CustomEditor(typeof(SceneManager))]
    // public class SceneManagerIns : Editor
    // {
    //     public override void OnInspectorGUI()
    //     {
    //         base.OnInspectorGUI();
    //         if (GUILayout.Button("±ä»¯"))
    //         {
    //             SceneManager.Instance.ChangeScene();
    //         }
    //     }
    // }
}
