/*******
 * 输入w加速，s减速，a左转，d右转
 * 
 * 
******* */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rd ;//刚体也就是小车
    public Vector3 speed;//速度向量  
    public float speed1 = 1.0f;//速度
    public float accelerated_speed = 1.25f;//加速
    public float resistance = 0.25f;//阻力
    public float brakespeed = 12.5f;//刹车
    public float h = 0.2f;//转动角度
    public float rotaspeed = 1.0f;//转动速度
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKey(KeyCode.W) )
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
            h -= rotaspeed;
            rd.angularVelocity = transform.up * h * speed1;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            h = 0.00f;
            rd.angularVelocity = transform.up * h * speed1;            
        }
        if (Input.GetKey(KeyCode.D))
        {
            h += rotaspeed;
            rd.angularVelocity = transform.up * h * speed1;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            h = 0.00f;
            rd.angularVelocity = transform.up * h*speed1;
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
        speed = this.transform.forward * speed1;
        rd.velocity = speed;
        //go.angularVelocity = transform.up*h*rotaspeed;
    }
    void OnCollisionEnter(Collision collision)
    {
        // 碰撞能变为0
        speed1 = 0;   
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

