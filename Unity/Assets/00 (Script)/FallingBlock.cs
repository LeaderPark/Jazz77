using System.Diagnostics.Contracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FallingBlock : MonoBehaviour
{
    MeshRenderer mesh;
    public bool isAlpha;
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        StartCoroutine(isOff());
    }

    void Update()
    {
        if(isAlpha)
        {
            mesh.material.DOColor(new Color32(255,255,255,100), 1f);
        }
        else
        {
            mesh.material.DOColor(new Color32(255,255,255,230), 1f);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Tilemap"))
        {
            // Destroy(this.gameObject);
            // Destroy(col.gameObject);
        }
        else if(col.gameObject.CompareTag("Player"))
        {
            
        }
    }

    public void breakBlock()
    {
        Destroy(this.gameObject);
    }

    IEnumerator isOff()
    {
        isAlpha = false;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(isOff());
    }
}
