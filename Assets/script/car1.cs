/*******
 * 输入w加速，s减速，a左转，d右转
 * 
 * 
******* */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rd ;//刚体也就是小车
    public Vector3 speed;//速度向量  
    public float speed1 = 1.0f;//速度
    public float accelerated_speed = 2.0f;//加速
    public float resistance = 0.25f;//阻力
    public float brakespeed = 6.0f;//刹车
    public float angle = 3.14f;//转动角度
    public float rotaspeed = 0.01f*Mathf.PI;//转动速度
    float dx, dz;
    float maxspeed1 = 15.0f;
    public GameObject database;
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && speed1<maxspeed1 )
        {
            speed1 += accelerated_speed * Time.deltaTime;            
        }
        if (Input.GetKey(KeyCode.S))
        {
            speed1 -= accelerated_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            if(speed1 > 0)
            {
                 speed1 -= brakespeed * Time.deltaTime;
                if(speed1 < 0)
                {
                    speed1 = 0.0f;
                }
            }
            else if (speed1 < 0)
            {
                speed1 += brakespeed * Time.deltaTime;
                if (speed1 > 0)
                {
                    speed1 = 0.0f;
                }
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            angle = angle - rotaspeed * speed1 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            angle = angle +  rotaspeed * speed1 * Time.deltaTime;
        }
        if(speed1 > 0)
        {
            speed1 -= resistance * Time.deltaTime;
            if (speed1 < 0) { speed1 = 0.0f; }
        }
        else if (speed1 < 0)
        {
            speed1 += resistance * Time.deltaTime;
            if (speed1 > 0) { speed1 = 0.0f; }
        }
        dz = Mathf.Cos(angle)*speed1;
        dx = Mathf.Sin(angle)*speed1;
        speed = new Vector3(dx,0.0f,dz);
        rd.velocity = speed;
        this.transform.localRotation = Quaternion.Euler(0, angle/2/Mathf.PI*360.0f, 0);
        //go.angularVelocity = transform.up*h*rotaspeed;
    }
    void OnCollisionEnter(Collision collision)
    {
        // 碰撞能变为0
        speed1 = 0;
        if (!collision.gameObject.name.Equals("ground"))
            database.GetComponent<database>().coli(1);
    }

    // 碰撞持续中
    void OnCollisionStay(Collision collision)
    {

    }

    // 碰撞结束
    void OnCollisionExit(Collision collision)
    {

    }
}

