using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlace : MonoBehaviour
{
    private void OnCollisionEnter(Collision col) 
    {
        if(col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Player>().Die();
            GameObject.Find("UIManager").GetComponent<UIManager>().gameoverUI();
        }
        else if(col.gameObject.CompareTag("Block"))
        {
            col.gameObject.GetComponent<FallingBlock>().breakBlock();
        }
    }
}
