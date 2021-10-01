using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject fallingBlock;
    bool isGameOver = false;

    public List<GameObject> block = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(falling());
    }

    void Update()
    {

    }

    IEnumerator falling()
    {
        while(!isGameOver)
        {
            int random1 = UnityEngine.Random.Range(0, 4);
            if (random1 == 0)
            {
                Debug.Log("0");
            }
            else if(random1 == 1)
            {
                Debug.Log("1");
            }
            else if(random1 == 2)
            {
                Debug.Log("2");
            }
            else if(random1 == 3)
            {
                Debug.Log("3");
            }

            int random = UnityEngine.Random.Range(0, 15);
            Vector3 pos = transform.GetChild(0).GetChild(random).transform.position;
            GameObject initblock = Instantiate(fallingBlock, new Vector3(pos.x, pos.y + 6, pos.z), Quaternion.identity);
            block.Add(initblock);

            yield return new WaitForSeconds(5.0f);
        }
    }
}
