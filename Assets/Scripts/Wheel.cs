using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WheelCollider))]
public class Wheel : MonoBehaviour
{
    public bool isSteering;
    public bool isDrive;
    private WheelCollider _collider;
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<WheelCollider>();
        Transform cur = transform;
        while (cur.parent != null) {
            cur = cur.parent;
            CarController car = cur.GetComponent<CarController>();
            if (car != null) {
                if (isSteering) car.steeringWheels.Add(_collider);
                if (isDrive) car.driveWheels.Add(_collider);
                break;
            }
        }
    }


    void FixedUpdate() {
        if (_collider == null) return;

        Vector3 pos;
        Quaternion rot;
        _collider.GetWorldPose(out pos, out rot);

        for (int i = 0; i < transform.childCount; i++) {
            Transform child = transform.GetChild(i);
            child.position = pos;
            child.rotation = rot;
        }
    }
}
