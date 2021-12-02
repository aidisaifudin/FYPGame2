using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GleyTrafficSystem
{
    public class UIInput : MonoBehaviour
    {


        public delegate void ButtonDown(string button);
        public static event ButtonDown onButtonDown;
        public static void TriggerButtonDownEvent(string button)
        {

            if (onButtonDown != null)
            {
                onButtonDown(button);
                
            }
        }

        public delegate void ButtonUp(string button);
        public static event ButtonUp onButtonUp;
        public static void TriggerButtonUpEvent(string button)
        {
            if (onButtonUp != null)
            {
                onButtonUp(button);
            }
        }
        bool left, right, up, down;


        float horizontalInput;
        float verticalInput;

        /// <summary>
        /// Initializes the input system based on platform used
        /// </summary>
        /// <returns></returns>
        public UIInput Initializ()
        {


            onButtonDown += PointerDown;
            onButtonUp += PointerUp;

            GameObject steeringUI = GameObject.Find("SteeringUI");
            if (steeringUI)
            {
                steeringUI.SetActive(false);
            }

            return this;
        }


        /// <summary>
        /// Get the steer input
        /// </summary>
        /// <returns></returns>
        public float GetHorizontalInput()
        {
            return horizontalInput;
        }


        /// <summary>
        /// Get acceleration input
        /// </summary>
        /// <returns></returns>
        public float GetVerticalInput()
        {
            return verticalInput;
        }


        /// <summary>
        /// Read input
        /// </summary>
        private void Update()
        {

            if (left)
            {
                horizontalInput -= Time.deltaTime;
            }
            else
            {
                if (right)
                {
                    horizontalInput += Time.deltaTime;
                }
                else
                {
                    horizontalInput = Mathf.MoveTowards(horizontalInput, 0, 5*Time.deltaTime);
                }
            }
            horizontalInput = Mathf.Clamp(horizontalInput, -1, 1);

            if(up)
            {
                verticalInput += Time.deltaTime;
            }
            else
            {
                if(down)
                {
                    verticalInput -= Time.deltaTime;
                }
                else
                {
                    verticalInput = 0;
                }
            }

            verticalInput = Mathf.Clamp(verticalInput, -1, 1);

            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

        }

        //Click event handlers for mobile devices

        private void PointerDown(string name)
        {
            if(name == "Restart")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            if (name == "Left")
            {
                left = true;
                right = false;
            }
            if (name == "Right")
            {
                right = true;
                left = false;
            }
            if (name == "Up")
            {
                up = true;
                down = false;
            }
            if (name == "Down")
            {
                down = true;
                up = false;
            }
        }

        private void PointerUp(string name)
        {
            if (name == "Left")
            {
                left = false;
            }
            if (name == "Right")
            {
                right = false;
            }
            if (name == "Up")
            {
                up = false;
            }
            if (name == "Down")
            {
                down = false;
            }
        }

        private void OnDestroy()
        {
            onButtonDown -= PointerDown;
            onButtonUp -= PointerUp;
        }

    }
}
