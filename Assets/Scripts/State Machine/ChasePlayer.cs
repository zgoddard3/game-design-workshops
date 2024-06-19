using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class ChasePlayer : AgentState
{
    private GameObject player;
    private AgentInput _input;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _input = GetComponent<AgentInput>();
    }

    public override AgentState Run() {
        Vector3 delta = player.transform.position - transform.position;
        delta.y = 0f;
        if (delta.magnitude > 5f) {
            _input.MoveInput(delta.normalized);
        } else {
            _input.MoveInput(Vector3.zero);
        }

        delta = transform.InverseTransformVector(delta);
        float angle = Mathf.Atan2(delta.x, delta.z);
        _input.LookInput(Vector2.right*angle);
        
        return this;
    }
}
