using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : AgentState
{
    private GameObject player;
    public GameObject Player {
        get { return player; }
    }
    private AgentInput _input;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
        _input = GetComponent<AgentInput>();
    }

    public override void Run() {
        Vector3 delta = player.transform.position - transform.position;
        delta = transform.InverseTransformVector(delta);
        delta.y = 0f;
        if (delta.magnitude > 5f) {
            _input.MoveInput(new Vector2(delta.x, delta.z).normalized);
        } else {
            _input.MoveInput(Vector2.zero);
        }

        
        float angle = Mathf.Atan2(delta.x, delta.z);
        _input.LookInput(Vector2.right*angle);

        _input.FireInput(true);
    }
}
