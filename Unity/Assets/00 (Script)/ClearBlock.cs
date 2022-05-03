using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class ClearBlock : MonoBehaviour
{

    public Camera camera;
    public LayerMask block;
    public LayerMask player;
    RaycastHit rayhit;
    Ray ray;

    GameObject falligblock;

    public float rayDistance = 82f;

    void Start()
    {
        
    }
    private void Update()
    {
        ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.49f, 0.5f));
        
        if (Physics.Raycast(ray, out rayhit, rayDistance, block))
        {
            Debug.DrawRay(ray.origin, rayhit.point, Color.red, 10f);
            rayhit.transform.GetComponent<FallingBlock>().isAlpha = true;
        }
    }

}
