using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpPower = 5f;

    Rigidbody rigid;
    Vector3 movement;
    float h, v;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        this.transform.position = GameObject.Find("SpawnPoint").transform.position;
    }
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void FixedUpdate()
    {
        Move();
    }


    void Jump()
    {
        rigid.AddForce(jumpPower * Vector3.up, ForceMode.Impulse);
    }

    void Move()
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * moveSpeed * Time.deltaTime;
        rigid.MovePosition(transform.position + movement);
    }

    public void touchblock()
    {

    }
}
