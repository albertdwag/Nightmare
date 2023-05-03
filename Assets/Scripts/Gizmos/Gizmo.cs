using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    public SphereCollider sphereCollider;
    public Color gizmoColor = Color.red;

    private void OnValidate()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, sphereCollider.radius);
    }
}
