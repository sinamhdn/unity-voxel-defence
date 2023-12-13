using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Block))]
public class EditorCube : MonoBehaviour
{
    // [SerializeField][Range(1f, 20f)] float gridSize = 10f;
    // const int gridSize = 10;
    // Vector3 snapPosition;
    Block block;

    void Awake()
    {
        block = GetComponent<Block>();
    }

    void Start()
    {

    }

    void Update()
    {

        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        // snapPosition.x = Mathf.RoundToInt(transform.position.x / 10f) * 10f;
        // snapPosition.z = Mathf.RoundToInt(transform.position.z / 10f) * 10f;
        // transform.position = new Vector3(snapPosition.x, 0f, snapPosition.z);
        transform.position = new Vector3(block.GetSnapPosition().x, 0f, block.GetSnapPosition().y);
    }

    private void UpdateLabel()
    {
        int gridSize = block.GetGridSize();
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        // string blockLable = snapPosition.x / gridSize + "," + snapPosition.z / gridSize;
        string blockLable = block.GetSnapPosition().x / gridSize +
                            "," +
                            block.GetSnapPosition().y / gridSize;
        textMesh.text = blockLable;
        gameObject.name = blockLable;
    }
}
