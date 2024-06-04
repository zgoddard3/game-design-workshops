using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public float damage;

    void OnCollisionEnter(Collision collision) {
        collision.gameObject.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);
    }

    void OnTriggerEnter(Collider other) {
        other.gameObject.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);
    }
}
