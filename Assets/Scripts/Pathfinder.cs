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
    List<Block> route = new List<Block>();
    Dictionary<Vector2Int, Block> grid = new Dictionary<Vector2Int, Block>();
    Queue<Block> queue = new Queue<Block>();
    Vector2Int[] directions ={
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.left,
        Vector2Int.down,
    };

    void Update()
    {
        // tries to set route color from here
        // but it adds too much overload as it runs foreach each frame
        // ChangeRouteColor();
    }

    void StartPathfinding()
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
        BreadthFirstSearch();
        GenerateRoute();
        // LookupNeighbours();
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

    public void ChangeStartEndColor()
    {
        startWaypoint = world.transform.GetChild(0).GetComponent<Block>();
        endWaypoint = world.transform.GetChild(world.transform.childCount - 1).GetComponent<Block>();
        startWaypoint.SetColorOfTop(Color.yellow);
        endWaypoint.SetColorOfTop(Color.magenta);
    }

    // void ChangeRouteColor()
    // {
    //     var blocks = FindObjectsOfType<Block>();
    //     foreach (Block block in blocks)
    //     {
    //         block.SetRouteColor();
    //     }
    // }

    void BreadthFirstSearch()
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
            // try catch can be used here or if (grid.ContainsKey(lookupNeighbourCoordinate)) on is enough
            // but to have a reference i used both
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
            // neighbour.exploredFrom = searchOrigin.gameObject;
            neighbour.exploredFrom = searchOrigin;
            print("Queueing " + neighbour);
        }
    }

    void GenerateRoute()
    {
        route.Add(endWaypoint);
        endWaypoint.isPlaceable = false;
        Block previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint)
        {
            route.Add(previous);
            previous.isPlaceable = false;
            previous = previous.exploredFrom;
        }
        route.Add(startWaypoint);
        startWaypoint.isPlaceable = false;
        route.Reverse();
    }

    // because by default scripts execute random
    // and there is a possibility that unity call
    // move before pathfinder if we generate path 
    // at the start list might be empty when we
    // call GetRoute so we move the route generation
    // methods to get method
    public List<Block> GetRoute()
    {
        if (route.Count == 0)
        {
            StartPathfinding();
        }
        return route;
    }
}
