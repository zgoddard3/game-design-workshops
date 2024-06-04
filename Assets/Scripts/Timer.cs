using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    private float time = 0f;
    public float interval = 1f;

    public UnityEvent onTimeout;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;

        if (time > interval) {
            time %= interval;
            onTimeout.Invoke();
        }
    }
}
