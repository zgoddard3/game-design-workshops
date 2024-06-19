using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public AgentState currentState;

    void FixedUpdate()
    {
        currentState = currentState?.Run();
    }
}
