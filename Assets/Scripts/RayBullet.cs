using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Modular{

public class RayBullet : MonoBehaviour
{
    public float speed;
    public float gravity;
    public LayerMask layerMask;
    public UnityEvent OnHit;
    private Vector3 velocity;
    
    void Start()
    {
        velocity = transform.TransformVector(Vector3.forward*speed);
    }

    void FixedUpdate() {
        Vector3 dp = velocity*Time.fixedDeltaTime;

        RaycastHit hit;
        Physics.Raycast(transform.position, dp, out hit, dp.magnitude, layerMask);

        if (hit.collider != null) {
            OnHit.Invoke();
        }

        transform.position += dp;
        velocity.y -= gravity * Time.fixedDeltaTime;
    }

}

}
