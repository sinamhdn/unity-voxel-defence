using UnityEngine;

public class Block : MonoBehaviour
{
    const int gridSize = 10;
    Vector2Int snapPosition;

    void Start()
    {

    }

    void Update()
    {

    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetSnapPosition()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize) * gridSize,
            Mathf.RoundToInt(transform.position.z / gridSize) * gridSize
        );
    }
}
