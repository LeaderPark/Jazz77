using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBlock : MonoBehaviour
{
    public Material clearhalf;
    public Material clear;
    public Camera camera;
    public LayerMask block;
    public LayerMask player;
    RaycastHit rayhit;
    Ray ray;

    GameObject falligblock;

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
            falligblock = rayhit.transform.gameObject;
            rayhit.transform.GetComponent<MeshRenderer>().material = clearhalf;
        }
        else if (Physics.Raycast(ray, out rayhit, rayDistance, player))
        {
            Debug.DrawLine(ray.origin, rayhit.point, Color.red);
            //falligblock.GetComponent<MeshRenderer>().material = clear;
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
