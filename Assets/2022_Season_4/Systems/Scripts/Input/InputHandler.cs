using UnityEngine;

namespace Systems.Inputs
{
    public class InputHandler : MonoBehaviour
    {
        private MoveForward moveForward = new MoveForward();

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void PlayerInputHandler(){
            if (Input.GetKeyDown(KeyCode.W))
            {
                moveForward.Execute();
            }
        }
    }
}