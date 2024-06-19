using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentState : MonoBehaviour
{
    public virtual AgentState Run() {
        return this;
    }
}
