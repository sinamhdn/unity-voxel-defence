using UnityEngine;

// allowed to have public variables because this class just holds data
public class Block : MonoBehaviour
{
    [SerializeField] Material material;
    public bool isStartNode = false;
    public bool isEndNode = false;
    public bool isRouteNode = false;
    public bool isExplored = false;
    public bool isPlaceable = true;
    public Block exploredFrom;
    const int gridSize = 10;
    // Vector2Int snapPosition;

    void Update()
    {
        SetRouteColor();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                print("OnMouseOver - " + gameObject.name);
            }
            else
            {
                print("CANT PLACE HERE!!");
            }
        }
    }

    public void SetRouteColor()
    {
        if (!material || !exploredFrom) return;
        if (isRouteNode) SetMaterialOfTop(material);
        FindObjectOfType<Pathfinder>().ChangeStartEndColor();
        //Block currentNode = this;
        if (isEndNode || isRouteNode)
        {
            //exploredFrom.GetComponent<Block>().SetMaterialOfTop(material);
            exploredFrom.isRouteNode = true;
            // exploredFrom.GetComponent<Block>().isRouteNode = true;
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
