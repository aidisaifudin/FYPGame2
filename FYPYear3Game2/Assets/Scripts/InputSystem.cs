using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public enum ControlMode { Keyboard = 1 , Touch = 2};

public class InputSystem : MonoBehaviour
{
    public ControlMode control;
    public float Accel;
    public float Steer;
    public float Brake;
    public GameObject UI;

    public void AccelInput(float input){Accel = input;}
    public void SteerInput(float input){ Accel = input; }
    public void BrakeInput(float input){ Brake = input; }
  
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(control == ControlMode.Keyboard)
        //{
        //    Accel = Input.GetAxis("Vertical");
        //    Steer = Input.GetAxis("Horizontal");
        //    Brake = Input.GetAxis("Jump");
        //    UI.SetActive(false);
        //}
        //else
        //{
        //    UI.SetActive(true);
        //}
    }

     void FixedUpdate()
    {
        
    }
}
