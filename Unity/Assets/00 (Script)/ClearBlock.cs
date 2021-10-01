using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBlock : MonoBehaviour
{
    public Material clear;
    public Camera camera;
    public LayerMask block;
    public LayerMask player;
    RaycastHit rayhit;
    Ray ray;

    public float rayDistance = 82f;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.49f, 0.5f));
        if (Physics.Raycast(ray, out rayhit, rayDistance, block))
        {
            Debug.DrawLine(ray.origin, rayhit.point, Color.red);
            //clear.color = new Color(190, 190, 190, 100);
        }
        else if (Physics.Raycast(ray, out rayhit, rayDistance, player))
        {
            Debug.DrawLine(ray.origin, rayhit.point, Color.red);
            //clear.color = new Color(190, 190, 190, 255);
        }
    }
}
