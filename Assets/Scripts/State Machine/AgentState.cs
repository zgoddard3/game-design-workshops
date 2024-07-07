using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public class AgentState : MonoBehaviour
{
    public Transition[] transitions;

    protected virtual void Start() {
        foreach (Transition transition in transitions) {
            transition.stateMachine = GetComponent<StateMachine>();
        }
    }

    public virtual void Run() {}

    public AgentState CheckTransitions() {
        foreach (Transition transition in transitions) {
            if (transition.Check()) {
                return transition.nextState;
            }
        }
        return this;
    }
}
