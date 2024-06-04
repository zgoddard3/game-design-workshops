using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modular{

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float speed;
    private new Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.TransformVector(Vector3.forward*speed);
    }

}

}
