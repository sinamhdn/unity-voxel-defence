using UnityEngine;

// allowed to have public variables because this class just holds data
public class Block : MonoBehaviour
{
    [SerializeField] Material material;
    public bool isStartNode = false;
    public bool isEndNode = false;
    public bool isRouteNode = false;
    public bool isExplored = false;
    public GameObject exploredFrom;
    const int gridSize = 10;
    // Vector2Int snapPosition;

    void Update()
    {
        SetRouteColor();
    }

    void SetRouteColor()
    {
        if (!material || !exploredFrom) return;
        //Block currentNode = this;
        if (isEndNode || isRouteNode)
        {
            //exploredFrom.GetComponent<Block>().SetMaterialOfTop(material);
            SetMaterialOfTop(material);
            exploredFrom.GetComponent<Block>().isRouteNode = true;
        }
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

    public void SetMaterialOfTop(Material material)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        //color.a = 0.1f;
        topMeshRenderer.material = material;
    }

    public void SetColorOfTop(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        //color.a = 0.1f;
        topMeshRenderer.material.color = color;
    }
}
