using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.Events;

public class WeaponControl : MonoBehaviour
{
    public float cooldown;
    public bool automatic;
    public UnityEvent onFire;
    private float _cooldown;
    private bool _ready;
    private StarterAssetsInputs _input;
    

    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_cooldown > 0) _cooldown -= Time.deltaTime;

        if (_cooldown <= 0 && _input.fire && _ready) {
            onFire.Invoke();
            _cooldown = cooldown;
            if (!automatic) _ready = false;
        }else if (!_input.fire) _ready = true;
        
    }


}
