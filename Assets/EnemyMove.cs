using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // [SerializeField] List<Block> path;
    // List<Block> path;
    List<Transform> path;
    World world;

    // Start is called before the first frame update
    void Start()
    {
        // path = new List<Block>();
        path = new List<Transform>();
        // path = FindObjectsOfType<Block>().ToList<Block>();
        // path = FindObjectsOfType<Block>().OrderBy(block => block.name).ToList<Block>();
        // path = FindObjectsOfType<Block>().OrderBy(block => block.transform.position.magnitude).ToList<Block>();
        // path = FindObjectsOfType<Block>().OrderBy(block => block.transform.parent).ToList<Block>();

        world = FindObjectOfType<World>();
        for (int i = 0; i < world.transform.GetChildCount(); i++)
        {
            path.Add(world.transform.GetChild(i));
        }

        StartCoroutine(FollowPath());
        //InvokeRepeating("Say hello!!", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FollowPath()
    {
        foreach (var block in path)
        {
            // print(block.gameObject.name);
            transform.position = block.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }
}
