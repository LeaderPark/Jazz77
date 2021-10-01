using UnityEngine;

public class MyGizimo : MonoBehaviour
{
    public Color color = Color.red;
    public Vector3 radius;

    void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawCube(transform.position, radius);
    }
}
