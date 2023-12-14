using UnityEngine;

// allowed to have public variables because this class just holds data
public class Block : MonoBehaviour
{
    public bool isExplored = false;
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
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    public void SetColorOfTop(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        //color.a = 0.1f;
        topMeshRenderer.material.color = color;
    }
}
