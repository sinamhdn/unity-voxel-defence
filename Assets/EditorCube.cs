using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class EditorCube : MonoBehaviour
{
    [SerializeField][Range(1f, 20f)] float gridSize = 10f;
    TextMesh textMesh;

    void Start()
    {

    }

    void Update()
    {
        Vector3 snapPosition;
        textMesh = GetComponentInChildren<TextMesh>();
        snapPosition.x = Mathf.RoundToInt(transform.position.x / 10f) * 10f;
        snapPosition.z = Mathf.RoundToInt(transform.position.z / 10f) * 10f;
        string blockLable = snapPosition.x / gridSize + "," + snapPosition.z / gridSize;
        transform.position = new Vector3(snapPosition.x, 0f, snapPosition.z);
        textMesh.text = blockLable;
        gameObject.name = blockLable;
    }
}
