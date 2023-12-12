using UnityEngine;

[ExecuteInEditMode]
public class SnapGrid : MonoBehaviour
{
    [SerializeField][Range(1f, 20f)] float gridSize = 10f;

    void Update()
    {
        Vector3 snapPosition;
        snapPosition.x = Mathf.RoundToInt(transform.position.x / 10f) * 10f;
        snapPosition.z = Mathf.RoundToInt(transform.position.z / 10f) * 10f;
        transform.position = new Vector3(snapPosition.x, 0f, snapPosition.z);
    }
}
