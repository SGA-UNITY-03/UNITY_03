using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankGizmo : MonoBehaviour
{
    public Color myColor = Color.green;

    private void OnDrawGizmos()
    {
        Gizmos.color = myColor;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }

}
