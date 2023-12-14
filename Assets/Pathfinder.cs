using System.Collections.Generic;
using UnityEngine;

// pathfinding using breadth first search
public class Pathfinder : MonoBehaviour
{
    // [SerializeField] Block startBlock, EndBlock;
    bool haltPathfinding = false;
    Block searchOrigin;
    Block startWaypoint, endWaypoint;
    World world;
    Dictionary<Vector2Int, Block> grid = new Dictionary<Vector2Int, Block>();
    Queue<Block> queue = new Queue<Block>();
    Vector2Int[] directions ={
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.left,
        Vector2Int.down,
    };

    // Start is called before the first frame update
    void Start()
    {
        world = FindObjectOfType<World>();
        startWaypoint = world.transform.GetChild(0).GetComponent<Block>();
        endWaypoint = world.transform.GetChild(world.transform.childCount - 1).GetComponent<Block>();
        startWaypoint.isStartNode = true;
        endWaypoint.isEndNode = true;
        print("START WAYPOINT ---->> " + startWaypoint.name);
        print("END WAYPOINT ---->> " + endWaypoint.name);
        LoadBlocks();
        ChangeStartEndColor();
        FindPath();
        // LookupNeighbours();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadBlocks()
    {
        var blocks = FindObjectsOfType<Block>();
        foreach (Block block in blocks)
        {
            if (grid.ContainsKey(block.GetSnapPosition()))
            {
                Debug.LogError("SKIPPING OVERLAPPING BLOCK --> " + block.name);
                continue;
            }
            print("ADDED BLOCK TO DISCTIONARY --> " + block.name);
            grid.Add(block.GetSnapPosition(), block);
        }
    }

    void ChangeStartEndColor()
    {
        startWaypoint.SetColorOfTop(Color.yellow);
        endWaypoint.SetColorOfTop(Color.magenta);
    }

    void FindPath()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && !haltPathfinding)
        {
            searchOrigin = queue.Dequeue();
            print("Start seach from: " + searchOrigin + "!!!");
            HalfIfReachedEndNode();
            LookupNeighbours();
            searchOrigin.isExplored = true;
        }
        print("Pathfinding finished!!!");
    }

    void HalfIfReachedEndNode()
    {
        if (searchOrigin == endWaypoint)
        {
            print("Started from end node so stopped!!!");
            haltPathfinding = true;
            // break;
        }
    }

    void LookupNeighbours()
    {
        if (haltPathfinding) return;
        foreach (Vector2Int direction in directions)
        {
            Vector2Int lookupNeighbourCoordinate = searchOrigin.GetSnapPosition() + direction;
            try
            {
                EnqueueNewNeighbours(lookupNeighbourCoordinate);
            }
            catch
            {
                Debug.LogError("An Error Occured.");
            }
        }
    }

    void EnqueueNewNeighbours(Vector2Int lookupNeighbourCoordinate)
    {
        // if (!grid.ContainsKey(lookupNeighbourCoordinate)) continue;
        if (!grid.ContainsKey(lookupNeighbourCoordinate)) return;
        Block neighbour = grid[lookupNeighbourCoordinate];
        if (!neighbour.isExplored || queue.Contains(neighbour))
        {
            neighbour.SetColorOfTop(Color.cyan);
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchOrigin.gameObject;
            print("Queueing " + neighbour);
        }
    }
}
