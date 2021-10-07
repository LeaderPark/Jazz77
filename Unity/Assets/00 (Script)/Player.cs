using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpPower = 5f;

    public Transform jumpRayPoint;
    Rigidbody rigid;
    Vector3 movement;
    float h, v;

    RaycastHit rayhit;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        this.transform.position = GameObject.Find("SpawnPoint").transform.position;
    }
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        
        if (Physics.Raycast(jumpRayPoint.position, Vector3.down, 0.2f) && rigid.velocity.y <= 0)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        Debug.DrawRay(jumpRayPoint.position, Vector3.down, Color.red, 0.2f);
        Debug.Log(rigid.velocity.y);
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

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
