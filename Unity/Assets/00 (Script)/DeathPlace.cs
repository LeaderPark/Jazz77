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
            PopUpManager.instance.OpenPopUp("restart");
        }
        else if(col.gameObject.CompareTag("Block"))
        {
            col.gameObject.GetComponent<FallingBlock>().breakBlock();
        }
    }
}
