using UnityEngine;
using Systems.Transition;
using Systems.Resource;
using UnityEngine.UI;

namespace Systems.UI
{
    public class ExampleCanvas : MonoBehaviour
    {
        [SerializeField] InputField field;
        [SerializeField] string from, to;
        [SerializeField] string path, abName, aName;

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {

        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        void Update()
        {

        }

        public void TransitionScene(){
            TransitionManager.Instance.Transition(from, to);
        }

        public void AddScene(){
            TransitionManager.Instance.AddScene(field.text);
        }

        public void RemoveScene(){
            TransitionManager.Instance.RemoveScene(field.text);
        }

        public void AcctiveScene(){
            TransitionManager.Instance.ActiveScene(field.text);
        }

        public void ClearScene(){
            TransitionManager.Instance.ClearScene();
        }

        public void AddObj2Scene(){
            ResourceManager.Instance.AddObj2Scence(path);
        }

        public void AddObj2SceneByAB(){
            // ResourceManager.Instance.AddObj2ScenceByAssetBundle(aName);
            ResourceManager.Instance.AddObj2ScenceByAssetBundle<Image>(aName, abName);
        }

        public void AddObj2SceneAsync(){
            ResourceManager.Instance.AddObj2ScenceAsync(abName, aName);
        }
    }

}