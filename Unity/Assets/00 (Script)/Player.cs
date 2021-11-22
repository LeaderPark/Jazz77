using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpPower = 5f;

    private bool isDie = false;
    public Transform jumpRayPoint;
    Rigidbody rigid;
    Vector3 movement;   
    float x, z;

    RaycastHit rayhit;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        this.transform.position = GameObject.Find("SpawnPoint").transform.position;
        isDie = false;
    }
    void Update()
    {
        transform.localPosition = ClampPosition(transform.localPosition);
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        
        if(!isDie)
        {
            if (Physics.Raycast(jumpRayPoint.position, Vector3.down, 0.2f) && rigid.velocity.y <= 0)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                }
            }
        }

        if(this.gameObject.transform.position.y <= -3f)
        {
            isDie = true;
            PopUpManager.instance.OpenPopUp("restart");
        }

        Debug.DrawRay(jumpRayPoint.position, Vector3.down, Color.red, 0.2f);
    }

    void FixedUpdate()
    {
        if(!isDie)
        {
            Move();
        }
    }

    void Jump()
    {
        rigid.AddForce(jumpPower * Vector3.up, ForceMode.Impulse);
    }

    void Move()
    {
        movement.Set(x, 0f, z);
        movement = movement.normalized * moveSpeed * Time.deltaTime;
        rigid.MovePosition(transform.position + movement);
        //transform.Translate(new Vector3(x, 0, z) * moveSpeed * Time.deltaTime);
    }

    public Vector3 ClampPosition(Vector3 position)
    {
        return new Vector3
        (
            // 좌우로 움직이는 이동범위
            Mathf.Clamp(position.x, -1.8f, 1.8f),
            Mathf.Clamp(position.y, -5f, 100f),
            Mathf.Clamp(position.z, 2.2f, 5.8f)
        );
    }
}
