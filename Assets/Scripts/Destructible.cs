using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modular {

public class Destructible : MonoBehaviour
{
    public void Die() {
        Destroy(gameObject);
    }
}

}
