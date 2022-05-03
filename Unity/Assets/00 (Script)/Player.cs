using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpPower = 5f;
    public float instantiateBlockCoolTime = 0f;

    private float degree = 0f;

    private bool isDie = false;
    public Transform jumpRayPoint;
    public GameObject spawnBlock;
    Rigidbody rigid;
    Vector3 movement;   
    float h,v;

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
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        
        if(!isDie)
        {
            if (Physics.Raycast(jumpRayPoint.position, Vector3.down, 0.2f) && rigid.velocity.y <= 0)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                }
            }
            float coolTime =+ Time.time;
            Debug.Log(coolTime);
            if(coolTime >= instantiateBlockCoolTime)
            {
                if(Input.GetKeyDown(KeyCode.F))
                {
                    InstantiateBlock();
                    coolTime = 0f;
                }
            }
        }

        if(this.gameObject.transform.position.y <= -3f)
        {
            isDie = true;
            PopUpManager.instance.OpenPopUp("restart");
        }
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
        Vector3 dir = Vector3.right * h + Vector3.forward * v;
        dir.Normalize();
        transform.position += dir * moveSpeed * Time.deltaTime;

        if(dir == new Vector3(1,0,0))
            degree = 90f;
        else if(dir == new Vector3(-1,0,0))
            degree = 270f;
        else if(dir == new Vector3(0,0,1))
            degree = 0f;
        else if(dir == new Vector3(0,0,-1))
            degree = 180f;

        float rot = Mathf.LerpAngle(
            transform.eulerAngles.y, 
            degree, 
            Time.deltaTime * 6f);

        transform.eulerAngles = new Vector3(0, rot, 0);
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

    public void InstantiateBlock()
    {
        Debug.Log("Instantiate Block");
        Instantiate(spawnBlock, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Quaternion.Euler(-90,0,0));
    }
}
