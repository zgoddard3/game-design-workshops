using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public AgentState currentState;

    public Dictionary<string, float> properties;

    private Transform player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        properties = new Dictionary<string, float>();
        properties["Player Distance"] = 100f;

    }

    void FixedUpdate()
    {
        UpdateProperties();
        currentState = currentState?.CheckTransitions();
        currentState?.Run();
    }

    private void UpdateProperties() {
        properties["Player Distance"] = (player.position - transform.position).magnitude;
    }
}
