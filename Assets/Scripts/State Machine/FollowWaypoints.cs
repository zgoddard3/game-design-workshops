using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : AgentState
{
    public float threshold = 0.5f;
    public Transform waypoints;
    private Transform curWaypoint;
    private int index;
    private AgentInput _input;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        curWaypoint = waypoints.GetChild(0);
        index = 0;
        _input = GetComponent<AgentInput>();
    }

    public override void Run() {
        Vector3 delta = curWaypoint.transform.position - transform.position;

        delta = transform.InverseTransformVector(delta);
        delta.y = 0f;
        _input.MoveInput(new Vector2(delta.x, delta.z).normalized);
        
        float angle = Mathf.Atan2(delta.x, delta.z);
        _input.LookInput(Vector2.right*angle);

        if (delta.magnitude < threshold) {
            index = (index + 1) % waypoints.childCount;
            curWaypoint = waypoints.GetChild(index);
        }
    }
}
