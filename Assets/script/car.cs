/*******
 * ����w���٣�s���٣�a��ת��d��ת
 * 
 * 
******* */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rd ;//����Ҳ����С��
    public Vector3 speed;//�ٶ�����  
    public float speed1 = 1.0f;//�ٶ�
    public float accelerated_speed = 1.25f;//����
    public float resistance = 0.25f;//����
    public float brakespeed = 12.5f;//ɲ��
    public float h = 0.2f;//ת���Ƕ�
    public float rotaspeed = 1.0f;//ת���ٶ�
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
        // ��ײ�ܱ�Ϊ0
        speed1 = 0;   
    }

    // ��ײ������
    void OnCollisionStay(Collision collision)
    {

    }

    // ��ײ����
    void OnCollisionExit(Collision collision)
    {

    }
}

