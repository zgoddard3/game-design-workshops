using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Direction = GridWorld.Direction;
using Random = UnityEngine.Random;

public class GridCell : MonoBehaviour
{
    private GridWorld gridWorld;
    private GameObject obj;
    private List<WaveCell> possibilities;
    private bool collapsed;

    // Start is called before the first frame update
    void Start()
    {
        gridWorld = transform.parent.GetComponent<GridWorld>();
        possibilities = new List<WaveCell>(gridWorld.waveCells.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clear() {
        for (int i = 0; i < transform.childCount; i++) {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public void MakeMazeCell() {
        obj = Instantiate(gridWorld.mazeCell, transform.position, transform.rotation, transform);
    }

    public void Connect(Direction direction) {
        Transform mazeCell = transform.GetChild(0);
        switch (direction) {
            case Direction.NORTH:
                Destroy(mazeCell.Find("North Wall").gameObject);
                break;
            case Direction.EAST:
                Destroy(mazeCell.Find("East Wall").gameObject);
                break;
            case Direction.SOUTH:
                Destroy(mazeCell.Find("South Wall").gameObject);
                break;
            case Direction.WEST:
                Destroy(mazeCell.Find("West Wall").gameObject);
                break;
        }
    }

    public void MakeWaveCell() {
        obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.transform.parent = transform;

        possibilities.Clear();
        possibilities.AddRange(gridWorld.waveCells);

        collapsed = false;
    }

    public bool Constrain(GridCell neighbor) {
        int l = possibilities.Count;
        List<WaveCell> temp = new List<WaveCell>();
        foreach (WaveCell waveCell1 in neighbor.possibilities) {
            foreach (WaveCell waveCell2 in possibilities) {
                if (waveCell2.adjacency.Contains(waveCell1)) {
                    temp.Add(waveCell2);
                }
            }
        }
        possibilities = temp;
        return l < possibilities.Count;
    }

    public void Collapse() {
        int i = Random.Range(0, possibilities.Count);
        WaveCell waveCell= possibilities[i];
        possibilities.Clear();
        possibilities.Add(waveCell);

        Destroy(transform.GetChild(0).gameObject);
        Instantiate(waveCell.obj, transform.position, transform.rotation, transform);

        collapsed = true;
    }

    public int Entropy() {
        if (collapsed) return 0;
        return possibilities.Count;
    }
}
