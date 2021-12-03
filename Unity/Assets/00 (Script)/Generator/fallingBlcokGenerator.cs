using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingBlcokGenerator : MonoBehaviour
{
    public Transform tilePrefab; //Ÿ�� ������
    public Vector2 mapSize; //�� ������

    [Range(0, 1)]
    public float outlinePercent; //�׵θ� ����

    private void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        string holderName = "FallingBlcok Spawn";
        if(transform.Find(holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }

        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;

        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                Vector3 tilePosition = new Vector3(-mapSize.x / 2 + 0.5f + x, 0, mapSize.y / 2 + 0.5f + y); //Ÿ�� ��ġ ����
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.up)); //Ÿ�� ����
                newTile.localScale = Vector3.one * (1 - outlinePercent); //�׵θ� ���� ����
                newTile.parent = mapHolder; //�θ� ����
            }
        }
        mapHolder.transform.position = transform.localPosition;
    }
}
