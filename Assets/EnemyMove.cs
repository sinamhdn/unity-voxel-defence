using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // [SerializeField] List<Block> path;
    // List<Block> path;
    List<Transform> directPath;
    World world;

    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var route = pathfinder.GetRoute();
        StartCoroutine(FollowPath(route));
        // FollowDirectPath();
    }

    void FollowDirectPath()
    {
        // path = new List<Block>();
        directPath = new List<Transform>();
        // path = FindObjectsOfType<Block>().ToList<Block>();
        // path = FindObjectsOfType<Block>().OrderBy(block => block.name).ToList<Block>();
        // path = FindObjectsOfType<Block>().OrderBy(block => block.transform.position.magnitude).ToList<Block>();
        // path = FindObjectsOfType<Block>().OrderBy(block => block.transform.parent).ToList<Block>();
        world = FindObjectOfType<World>();
        for (int i = 0; i < world.transform.childCount; i++)
        {
            directPath.Add(world.transform.GetChild(i));
        }
        // StartCoroutine(FollowPath());
        // InvokeRepeating("Say hello!!", 1f, 1f);
        // path = new List<Block>();
        directPath = new List<Transform>();
        // path = FindObjectsOfType<Block>().ToList<Block>();
        // path = FindObjectsOfType<Block>().OrderBy(block => block.name).ToList<Block>();
        // path = FindObjectsOfType<Block>().OrderBy(block => block.transform.position.magnitude).ToList<Block>();
        // path = FindObjectsOfType<Block>().OrderBy(block => block.transform.parent).ToList<Block>();
        world = FindObjectOfType<World>();
        for (int i = 0; i < world.transform.childCount; i++)
        {
            directPath.Add(world.transform.GetChild(i));
        }
        StartCoroutine(FollowDPath());
        // InvokeRepeating("Say hello!!", 1f, 1f);
    }

    IEnumerator FollowDPath()
    {
        foreach (var block in directPath)
        {
            // print(block.gameObject.name);
            transform.position = block.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator FollowPath(List<Block> path)
    {
        foreach (var block in path)
        {
            transform.position = block.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }
}
