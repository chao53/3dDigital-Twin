using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class god : MonoBehaviour
{
    float rataspeed = 0.5f;
    public Vector3 mouse1 = new Vector3(10f,10f,10f);
    Vector3 speed;
    public Rigidbody rd;
    float speed1;
    float accelerated_speed = 6.0f;
    float resistance = 3.0f;//阻力
    float maxspeed1 = 10.0f;
    float dx = 0.0f,dz = 0.0f;
    public GameObject[] roadblock;
    public GameObject[] cars;
    AI_driver1 a3;
    // Start is called before the first frame update
    void Start()
    {
        cars = GameObject.FindGameObjectsWithTag("car");
        //mouse1 = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) && speed1 < maxspeed1)
        {
            resistance = 3.0f;
            dz += accelerated_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            resistance = 3.0f;
            dz -= accelerated_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            resistance = 3.0f;
            dx -= accelerated_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            resistance = 3.0f;
            dx += accelerated_speed * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.W) && speed1 < maxspeed1)
        {
            resistance = 6.0f;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            resistance = 6.0f;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            resistance = 6.0f;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            resistance = 6.0f;
        }
        float wheel = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 1000;

        if (dx > 0)
        {
            dx -= resistance * Time.deltaTime;
            if (dx < 0) { dx = 0.0f; }
        }
        else if (dx < 0)
        {
            dx += resistance * Time.deltaTime;
            if (dx > 0) { dx = 0.0f; }
        }

        if (dz > 0)
        {
            dz -= resistance * Time.deltaTime;
            if (dz < 0) { dz = 0.0f; }
        }
        else if (dz < 0)
        {
            dz += resistance * Time.deltaTime;
            if (dz > 0) { dz = 0.0f; }
        }

        speed.z = dz;
        speed.x = dx;
        //改变相机的位置
        this.transform.Translate(Vector3.forward * wheel);
        rd.velocity = speed;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouse = Input.mousePosition;
                  //2创建一个射线 从相机位置到鼠标点击的位置的方向上 
            Ray ray = Camera.main.ScreenPointToRay(mouse);
            //定义一个射线检测的保存对象 
            RaycastHit hit;//hit保存射线发射后碰撞的信息 
                           //开始碰撞检测，射线检测返回一个bool类型，true:有碰撞,false:无碰撞 
            if (Physics.Raycast(ray, out hit,1000f)) //碰撞检测(射线，碰撞结果给hit，射线的长度100米) 
            {
               mouse1 = hit.point;
            } 
            GameObject.Instantiate(Resources.Load<GameObject>("prefabs/luzhang (1)"), mouse1, Quaternion.Euler(new Vector3(0, 0, 0)));
            for (int i = 0; cars.Length != 0 && i < cars.Length; i++)
            {
                if (cars[i].GetComponent<AI_driver1>())
                {
                    a3 = cars[i].GetComponent<AI_driver1>();
                    a3.addroadblock = true;
                }
                if (cars[i].GetComponent<AI_driver>())
                {
                    AI_driver a2 = cars[i].GetComponent<AI_driver>();
                    a2.addroadblock = true;
                }
                if (cars[i].GetComponent<AI_driver2>())
                {
                    AI_driver2 a2 = cars[i].GetComponent<AI_driver2>();
                    a2.removeroadblock = true;
                }
            }
        }


        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("减少路障");
            Vector3 mouse = Input.mousePosition;
            //2创建一个射线 从相机位置到鼠标点击的位置的方向上 
            Ray ray = Camera.main.ScreenPointToRay(mouse);
            //定义一个射线检测的保存对象 
            RaycastHit hit;//hit保存射线发射后碰撞的信息 
                           //开始碰撞检测，射线检测返回一个bool类型，true:有碰撞,false:无碰撞 
            if (Physics.Raycast(ray, out hit, 1000f)) //碰撞检测(射线，碰撞结果给hit，射线的长度100米) 
            {
                mouse1 = hit.point;
            }
            roadblock = GameObject.FindGameObjectsWithTag("roadblock");
            int min = -1;
            float min1 = 1000.0f; 
            float length ;
            for (int i = 0; i < roadblock.Length; i++)
            {
                length = Mathf.Abs(roadblock[i].transform.position.x - mouse1.x) + Mathf.Abs(roadblock[i].transform.position.y - mouse1.y);
                if(length < 5.0f)
                {
                    if(length <min1)
                    {
                        min = i;
                        min1 = length;
                    }
                }
            }
            if (min != -1)
            {
                Destroy(roadblock[min]);
            }
            for(int i = 0;cars.Length!=0 && i < cars.Length;i++)
            {
                if (cars[i].GetComponent<AI_driver1>())
                {
                    a3 = cars[i].GetComponent <AI_driver1>();
                    a3.removeroadblock = true;
                }
                if (cars[i].GetComponent<AI_driver2>())
                {
                    AI_driver2 a2 = cars[i].GetComponent<AI_driver2>();
                    a2.removeroadblock = true;
                }
                if (cars[i].GetComponent<AI_driver>())
                {
                    AI_driver a2 = cars[i].GetComponent<AI_driver>();
                    a2.removeroadblock = true;
                }
            }
        }
    }
}
