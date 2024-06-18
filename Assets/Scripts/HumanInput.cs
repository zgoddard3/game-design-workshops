using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AgentInput))]
public class HumanInput : MonoBehaviour
{
    private AgentInput _input;

    void Start() {
        _input = GetComponent<AgentInput>();
    }

    public void OnMove(InputValue value)
    {
        _input.MoveInput(value.Get<Vector2>());
    }

    public void OnLook(InputValue value)
    {
        if(_input.cursorInputForLook)
        {
            _input.LookInput(value.Get<Vector2>());
        }
    }

    public void OnJump(InputValue value)
    {
        _input.JumpInput(value.isPressed);
    }

    public void OnSprint(InputValue value)
    {
        _input.SprintInput(value.isPressed);
    }
}
