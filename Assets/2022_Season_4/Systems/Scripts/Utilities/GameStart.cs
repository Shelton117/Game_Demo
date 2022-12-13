using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    Canvas mCanvas;
    // Start is called before the first frame update
    void Start()
    {
        mCanvas = new GameObject("main Canvas").AddComponent<Canvas>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
