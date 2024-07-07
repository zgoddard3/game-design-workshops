using System;
using Unity.VisualScripting;
using UnityEngine.Timeline;
using UnityEngine;

[Serializable]
public class Transition {
    public enum ComparisonType {
        Equal,
        Greater,
        Less,
    };
    public AgentState nextState;
    public string property;
    public float value;
    public ComparisonType comparisonType;

    [HideInInspector]
    public StateMachine stateMachine;


    public bool Check() {
        switch (comparisonType) {
            case ComparisonType.Equal:
                return stateMachine.properties[property] == value;
            case ComparisonType.Greater:
                return stateMachine.properties[property] > value;
            case ComparisonType.Less:
                return stateMachine.properties[property] < value;
        }
        return false;
    }
}