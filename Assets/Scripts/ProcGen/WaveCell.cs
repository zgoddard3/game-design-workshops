using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Data", menuName="ScriptableObjects/WaveCell", order=1)]
public class WaveCell : ScriptableObject
{
    public string cellName;
    public GameObject obj;
    public WaveCell[] adjacency;
}
