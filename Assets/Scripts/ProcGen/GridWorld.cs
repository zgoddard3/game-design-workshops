using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.Random;

public class GridWorld : MonoBehaviour
{
    public int width;
    public int length;

    private List<List<GridCell>> cells;
    private HashSet<Tuple<int,int>> closedSet;
    public GameObject mazeCell;

    public WaveCell[] waveCells;

    public enum Direction {
        NORTH,
        EAST,
        SOUTH,
        WEST,
    }

    private Dictionary<Direction, Tuple<int,int>> directions = new Dictionary<Direction, Tuple<int, int>>(4);
    private Dictionary<Direction, Direction> opposites = new Dictionary<Direction, Direction>(4);
    private bool shouldStep = false;
    
    void Awake() {
        directions.Add(Direction.NORTH, new Tuple<int,int>(1,0));
        directions.Add(Direction.EAST, new Tuple<int,int>(0,1));
        directions.Add(Direction.SOUTH, new Tuple<int,int>(-1,0));
        directions.Add(Direction.WEST, new Tuple<int,int>(0,-1));

        opposites.Add(Direction.NORTH, Direction.SOUTH);
        opposites.Add(Direction.EAST, Direction.WEST);
        opposites.Add(Direction.SOUTH, Direction.NORTH);
        opposites.Add(Direction.WEST, Direction.EAST);
    }

    // Start is called before the first frame update
    void Start()
    {
        mazeCell = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Maze Cell.prefab");
        closedSet = new HashSet<Tuple<int, int>>(width*length);

        cells = new List<List<GridCell>>(width);
        for (int i = 0; i < width; i++) {
            cells.Add(new List<GridCell>(length));
            for (int j = 0; j < length; j++) {
                GameObject go = new GameObject(String.Format("Cell ({0}, {1})", i, j));
                go.transform.parent = transform;
                go.transform.position = Vector3.forward*i + Vector3.right*j;
                cells[i].Add(go.AddComponent<GridCell>());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MazeFill() {

        closedSet.Clear();

        int i,j;
        for (i = 0; i < width; i++) {
            for (j = 0; j < length; j++) {
                cells[i][j].Clear();
                cells[i][j].MakeMazeCell();
            }
        }   

        i = Range(0, width);
        j = Range(0, length);

        StartCoroutine(RandomDepthFirst(i,j));
    }

    private IEnumerator RandomDepthFirst(int i, int j) {
        closedSet.Add(new Tuple<int, int>(i,j));
        List<Direction> neighbors = Neighbors(i, j);
        Shuffle(neighbors);
        
        foreach (Direction d in neighbors) {
            int x = i + directions[d].Item1;
            int y = j + directions[d].Item2;
            Tuple<int,int> xy = new Tuple<int,int>(x,y);
            if (closedSet.Contains(xy)) {continue;}

            cells[i][j].Connect(d);
            cells[x][y].Connect(opposites[d]);
            
            shouldStep = false;
            yield return new WaitUntil(()=>shouldStep);

            yield return StartCoroutine(RandomDepthFirst(x,y));
        }
    }

    public void WaveFill() {

        closedSet.Clear();

        int i,j;
        for (i = 0; i < width; i++) {
            for (j = 0; j < length; j++) {
                cells[i][j].Clear();
                cells[i][j].MakeMazeCell();
            }
        }   

        i = Range(0, width);
        j = Range(0, length);

        StartCoroutine(WaveFunctionCollapse());
    }

    private IEnumerator WaveFunctionCollapse() {
        yield return new WaitUntil(() => shouldStep);
    }

    private List<Direction> Neighbors(int i, int j) {
        List<Direction> neighbors = new List<Direction>(4);

        foreach (Direction direction in directions.Keys) {
            int x = i + directions[direction].Item1;
            if (x < 0 || x >= width) continue;

            int y = j + directions[direction].Item2;
            if (y < 0 || y >= length) continue;

            neighbors.Add(direction);
        }

        return neighbors;
    }

    private void Shuffle<T>(List<T> list) {
        T tmp;
        int j;
        for (int i = 0; i < list.Count; i++) {
            j = Range(0, list.Count);
            tmp = list[i];
            list[i] = list[j];
            list[j] = tmp;
        }
    }

    public void Step() {
        shouldStep = true;
    }
}
