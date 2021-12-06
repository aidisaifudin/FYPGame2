using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCycle : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;
    // Start is called before the first frame update
    private float angleBetween = 0.0f;
    public Transform target;
    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }
    public void Up()
    {

    }
    public void Left()
    {
        verticalInput = Input.GetAxis(VERTICAL);
    }
    public void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;

        currentbreakForce = isBreaking ? breakForce : 0f;


        ApplyBreaking();

    }

    private void ApplyBreaking()
    {

        frontLeftWheelCollider.brakeTorque = currentbreakForce;

        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }
    public void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;

    }

    private void UpdateWheels()
    {
      //  UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        //  UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        //  UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
       //  UpdateSingleWheel(frontRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

}
