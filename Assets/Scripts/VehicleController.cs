using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [System.Serializable]
    public class AxleInfo {
        public WheelCollider leftWheel;
        public WheelCollider rightWheel;
        public bool motor;
        public bool steering;
    }

    public float breakTorque;
    
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    
    //from: https://docs.unity3d.com/Manual/WheelColliderTutorial.html
    public void UpdateSteeringFixedUpdate(float motorTorque, float steering, bool breaks)
    {
        foreach (AxleInfo axleInfo in axleInfos) {
            if (breaks)
            {
                Debug.Log("break");
                axleInfo.leftWheel.brakeTorque = breakTorque;
                axleInfo.rightWheel.brakeTorque = breakTorque;
                break;
            }
            
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering * maxSteeringAngle;
                axleInfo.rightWheel.steerAngle = steering * maxSteeringAngle;
            }
            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = maxMotorTorque * motorTorque;
                axleInfo.rightWheel.motorTorque = maxMotorTorque * motorTorque;
            }
        }
        //TODO: update visuals
    }
    
    
    
    
}
