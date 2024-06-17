using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float maxTorque;
    public List<WheelCollider> steeringWheels;
    public List<WheelCollider> driveWheels;
    private StarterAssetsInputs _input;

    void Awake() {
        steeringWheels = new List<WheelCollider>();
        driveWheels = new List<WheelCollider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        print(GetComponent<Rigidbody>().inertiaTensor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        foreach (WheelCollider wheel in steeringWheels) {
            wheel.steerAngle = _input.move.x * 30f;
        }
        foreach (WheelCollider wheel in driveWheels) {
            wheel.motorTorque = _input.move.y * maxTorque;
        }
    }
}
