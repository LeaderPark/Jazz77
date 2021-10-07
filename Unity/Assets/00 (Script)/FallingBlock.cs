using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Tilemap"))
        {
            Destroy(this.gameObject);
            Destroy(col.gameObject);
        }
        else if(col.gameObject.CompareTag("Player"))
        {
            
        }
    }

    public void breakBlock()
    {
        Destroy(this.gameObject);
    }
}
