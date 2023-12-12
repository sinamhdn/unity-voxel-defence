using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class World : MonoBehaviour
{
    void Update()
    {
        List<Transform> childrenGameObjectList = new List<Transform>();
        foreach (Transform child in transform)
        {
            childrenGameObjectList.Add(child);
        }
        var sortedChildrenGameObjectList = childrenGameObjectList.OrderBy(gameObject => gameObject.name).ToList<Transform>();
        foreach (Transform child in sortedChildrenGameObjectList)
        {
            child.parent = transform;
        }
    }
}
