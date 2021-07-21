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
         //获取垂直数值
         float v = Input.GetAxis("Vertical");
         //设置刚体速度为 自身前方向*垂直数值*速度  控制刚体移动
         rb.velocity = this.transform.forward * v * speed;

         //获取水平数值
         float h = Input.GetAxis("Horizontal");
        //设置刚体角速度为 自身上方向*垂直数值*速度  控制刚体旋转
        rb.angularVelocity = this.transform.up * h * angularSpeed;
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
