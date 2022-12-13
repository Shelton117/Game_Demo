using Scripts.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace TTF_lite
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private Slider mSlider;
        [SerializeField] private GameObject mSphere;
        [SerializeField] private float scale = 30;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            mSphere.transform.localScale = mSlider.value * Vector3.one * scale;
        }
    }
}

