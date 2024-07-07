using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public float damage;

    public void ApplyDamage(GameObject go) {
        go.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);
    }

    void OnCollisionEnter(Collision collision) {
        collision.gameObject.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);
    }

    void OnTriggerEnter(Collider other) {
        ApplyDamage(other.gameObject);
    }
}
