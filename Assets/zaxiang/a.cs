using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a : MonoBehaviour
{

    private Rigidbody rb;
    public float speed = 2;
    public float angularSpeed = 1;


    void Awake()
    {
                 rb = this.GetComponent<Rigidbody>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
         Move();
    }
 
     void Move()
    {
         //��ȡ��ֱ��ֵ
         float v = Input.GetAxis("Vertical");
         //���ø����ٶ�Ϊ ����ǰ����*��ֱ��ֵ*�ٶ�  ���Ƹ����ƶ�
         rb.velocity = this.transform.forward * v * speed;

         //��ȡˮƽ��ֵ
         float h = Input.GetAxis("Horizontal");
        //���ø�����ٶ�Ϊ �����Ϸ���*��ֱ��ֵ*�ٶ�  ���Ƹ�����ת
        rb.angularVelocity = this.transform.up * h * angularSpeed;
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
