using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Direction = GridWorld.Direction;

public class GridCell : MonoBehaviour
{
    private GridWorld gridWorld;
    private GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        gridWorld = transform.parent.GetComponent<GridWorld>();
        
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
}
