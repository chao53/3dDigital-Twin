/*******
 * ����w���٣�s���٣�a��ת��d��ת
 * 
 * 
******* */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_driver2 : MonoBehaviour
{
    //public Transform targetpos;//Ŀ��λ��
    public Vector2 targetpos1 = new Vector2(-1.75f, -258.3f);//��һ����ת��
    public Vector2 targetpos2 = new Vector2(3.75f, -263.3f);//�ڶ�����ת��
    public Vector2 targetpos3 = new Vector2(140f, -263.3f);//��3����ת��
    public Vector2 targetpos4 = new Vector2(145f, -258.3f);//��4����ת��
    public Vector2 targetpos5 = new Vector2(145f, 5.4f);//��5����ת��
    public Vector2 targetpos6 = new Vector2(140f, 10.4f);//��6����ת��
    public Vector2 targetpos7 = new Vector2(-136.1f, 12.5f);//��7����ת��
    public Vector2 targetpos8 = new Vector2(-141.1f, 17.5f);//��8����ת��
    public Vector2 targetpos9 = new Vector2(-141.1f, 142.6f);//��9����ת��
    public Vector2 targetpos10 = new Vector2(-136.1f, 147.6f);//��10����ת��
    public Vector2 targetpos11 = new Vector2(-7.65f, 147.8f);//��11����ת��
    public Vector2 targetpos12 = new Vector2(-2.65f, 142.8f);//��12����ת��
    public GameObject light1;
    public GameObject light2;
    // Start is called before the first frame update
    float max;//�ɲ������
    float min;//���ɲ������
    float reduSpeed;//�����ٶ�
    public float maxspeed = 10.0f;//�����ʻ�ٶ�
    float maxspeed1;//����ʱ����ٶ�
    public Rigidbody rd;//����Ҳ����С��
    public Vector3 speed;//�ٶ�����
    public Vector3 forward;//�˶�����
    public float speed1 = 0.0f;//�ٶ�
    public float accelerated_speed = 2.0f;//���ٶ�
    public float resistance = 0.25f;//����
    public float brakespeed = 6.0f;//ɲ������ٶ�
    public Vector3 rotation;//��ת�Ƕ�
    float h = -0.2f;//ת�����ٶ�
    float x1, z1;//С����Ҫ�ڵ�һ�����̵��ж��Ƿ���Ҫͣ��
    float x2, z2;//С����Ҫ�ڵڶ������̵��ж��Ƿ���Ҫͣ��
    float x3, z3;//С��ֹͣ�ں��̵�ʱ��ֹλ��

    float time;//�̵�ʣ��ʱ��
    bool isRota = false;//
    bool isMove = true;
    bool isReduce = false;
    bool isReduce1 = false;
    light l;
    light l1;
    public bool addroadblock = false;
    public bool removeroadblock = false;
    public bool isfollow = false;
    public float carspeed;
    public GameObject car;
    public GameObject[] roadblock;
    public GameObject[] cars;
    public Vector3 speedforword;
    public GameObject database;
    void Start()
    {
        forward = speedforword;
        float time = maxspeed / (brakespeed + resistance);
        max = 0.5f * (brakespeed + resistance) * time * time;
        x1 = light1.transform.position.x;
        z1 = light1.transform.position.z + 25.28f + 5.64f + max + 2.0f;
        x2 = light2.transform.position.x + 25.34f + 5.64f + max + 2.0f;
        z2 = light2.transform.position.z;
        l = light1.GetComponent<light>();
        l1 = light2.GetComponent<light>();
        min = (accelerated_speed - resistance) * max / ((accelerated_speed - resistance) + (brakespeed + resistance)) + 2.0f;
        maxspeed1 = Mathf.Sqrt(2.0f * (brakespeed + resistance));
        cars = GameObject.FindGameObjectsWithTag("car");
        roadblock = GameObject.FindGameObjectsWithTag("roadblock");
    }

    // Update is called once per frame

    void Update()
    {
        if (isMove)
        {
            float time = speed1 / (brakespeed + resistance);
            max = 0.5f * (brakespeed + resistance) * time * time;
            isfollow = false;
            
            for (int i = 0; i < cars.Length && cars.Length != 0; i++)
            {
                if (Mathf.Abs(rd.position.x - cars[i].transform.position.x) + Mathf.Abs(rd.position.z - cars[i].transform.position.z) > 0.5f &&
                    rd.position.x + max + 2.0f + 2.5f + 5.0f < cars[i].transform.position.x && rd.position.x > cars[i].transform.position.x && rd.position.z < cars[i].transform.position.z + 2.0f && rd.position.z > cars[i].transform.position.z - 2.0f && rd.transform.forward.x > 0.9f)
                {
                    //Debug.Log("����");
                    isfollow = true;
                    car = cars[i];
                }
                if (Mathf.Abs(rd.position.x - cars[i].transform.position.x) + Mathf.Abs(rd.position.z - cars[i].transform.position.z) > 0.5f &&
                    rd.position.x - (max + 2.0f + 2.5f + 5.0f) < cars[i].transform.position.x && rd.position.x > cars[i].transform.position.x && rd.position.z < cars[i].transform.position.z + 2.0f && rd.position.z > cars[i].transform.position.z - 2.0f && rd.transform.forward.x < -0.9f)
                {
                    //Debug.Log("����");
                    isfollow = true;
                    car = cars[i];
                }
                if (Mathf.Abs(rd.position.x - cars[i].transform.position.x) + Mathf.Abs(rd.position.z - cars[i].transform.position.z) > 0.5f && rd.position.z - (max + 2.0f + 2.5f + 5.0f) < cars[i].transform.position.z &&
                    rd.position.z - (max + 2.0f + 2.5f + 5.0f) < cars[i].transform.position.z && rd.position.z > cars[i].transform.position.z && rd.position.x < cars[i].transform.position.x + 2.0f && rd.position.x > cars[i].transform.position.x - 2.0f && rd.transform.forward.z < -0.9f)
                {
                    //Debug.Log("����");
                    isfollow = true;
                    car = cars[i];
                }
                if (Mathf.Abs(rd.position.x - cars[i].transform.position.x) + Mathf.Abs(rd.position.z - cars[i].transform.position.z) > 0.5f &&
                    rd.position.z + (max + 2.0f + 2.5f + 5.0f) > cars[i].transform.position.z && rd.position.z < cars[i].transform.position.z && rd.position.x < cars[i].transform.position.x + 2.0f && rd.position.x > cars[i].transform.position.x - 2.0f && rd.transform.forward.z > 0.9f)
                {
                    isfollow = true;
                    car = cars[i];
                    //Debug.Log("����");
                }
            }
            //·��
            if (!isReduce)
            {
                isReduce1 = false;
                for (int i = 0; i < roadblock.Length && roadblock.Length != 0; i++)
                {
                    if (roadblock[i] == null)
                    {
                        continue;
                    }
                    if (rd.position.x > roadblock[i].transform.position.x - (max + 2.0f + 2.5f) && rd.position.x < roadblock[i].transform.position.x - (max - 2.0f + 2.5f) && rd.position.z < roadblock[i].transform.position.z + 2.0f && rd.position.z > roadblock[i].transform.position.z - 2.0f && rd.transform.forward.x > 0.9f)
                    {
                        isReduce1 = true;
                        Debug.Log("·��ͣ");
                    }

                    if (rd.position.x < roadblock[i].transform.position.x + (max + 2.0f + 2.5f) && rd.position.x > roadblock[i].transform.position.x + (max - 2.0f + 2.5f) && rd.position.z < roadblock[i].transform.position.z + 2.0f && rd.position.z > roadblock[i].transform.position.z - 2.0f && rd.transform.forward.x < -0.9f)
                    {
                        isReduce1 = true;
                        Debug.Log("·��ͣ");
                    }

                    if (rd.position.z > roadblock[i].transform.position.z && rd.position.z < roadblock[i].transform.position.z + (max + 2.0f + 2.5f) && rd.position.z > roadblock[i].transform.position.z + (max - 2.0f + 2.5f) && rd.position.x < roadblock[i].transform.position.x + 2.0f && rd.position.x > roadblock[i].transform.position.x - 2.0f && rd.transform.forward.z < -0.9f)
                    {
                        isReduce1 = true;
                        Debug.Log("·��ͣ");
                    }

                    if (rd.position.z > roadblock[i].transform.position.z - (max + 2.0f + 2.5f) && rd.position.z < roadblock[i].transform.position.z - (max - 2.0f + 2.5f) && rd.position.x < roadblock[i].transform.position.x + 2.0f && rd.position.x > roadblock[i].transform.position.x - 2.0f && rd.transform.forward.z > 0.9f)
                    {
                        isReduce1 = true;
                        Debug.Log("·��ͣ");
                    }
                }
            }

            //�����ж�
            if (rd.position.x < (x1 + 2.0f) && rd.position.x > x1 - 2.0f && rd.position.z < z1 + 0.2f && rd.position.z > z1 - 0.2f && isMove && !isReduce && !isfollow)
            {
                //�̵��Ƿ��ܹ�
                if (l.walk == 2 && !isReduce)
                {
                    if (((2.0f + time) * speed1 + (2.0f + time) * (maxspeed - speed1) * 0.5f) < max)
                    {
                        Debug.Log("�̵�ͣ");
                        isReduce = true;
                        x1 = light1.transform.position.x;
                        z1 = light1.transform.position.z + 25.28f + 5.64f + min;

                    }
                }
                //�Ƶ��Ƿ���Ҫͣ
                if (l.walk == 1 && !isReduce)
                {
                    if (time * speed1 > max)
                    {
                        Debug.Log("�Ƶ�ͣ");
                        isReduce = true;
                        x1 = light1.transform.position.x;
                        z1 = light1.transform.position.z + 25.28f + 5.64f + min;
                    }
                }
                if (l.walk == 3)
                {
                    isReduce = true;
                }
                if (l.walk == 0 && !isReduce)
                {
                    isReduce = true;
                    x1 = light1.transform.position.x;
                    z1 = light1.transform.position.z + 25.28f + 5.64f + min;
                }

            }
            if (rd.position.x < (x2 + 0.2f) && rd.position.x > (x2 - 0.2f) && rd.position.z < (z2 + 2.0f) && rd.position.z > (z2 - 2.0f) && isMove && !isReduce && !isfollow)
            {
                Debug.Log("sb");
                //�̵��Ƿ��ܹ�
                if (l1.walk == 2 && !isReduce)
                {
                    Debug.Log((2.0f + time) * speed1 + (2.0f + time) * (maxspeed - speed1) * 0.5f);
                    Debug.Log(max);
                    if (((2.0f + time) * speed1 + (2.0f + time) * (maxspeed - speed1) * 0.5f) < max)
                    {
                        Debug.Log("�̵�ͣ");
                        isReduce = true;
                        x3 = light2.transform.position.x+ 25.28f + 5.64f + min;
                        z3 = light2.transform.position.z;

                    }
                }
                //�Ƶ��Ƿ���Ҫͣ
                if (l1.walk == 1 && !isReduce)
                {
                    if (time * speed1 > max)
                    {
                        Debug.Log("�Ƶ�ͣ");
                        isReduce = true;
                        x3 = light2.transform.position.x + 25.28f + 5.64f + min;
                        z3 = light2.transform.position.z;
                    }
                }
                if ((l1.walk == 0 ||l1.walk == 3 )&& !isReduce)
                {
                    Debug.Log("hong��ͣ");
                    isReduce = true;
                    x3 = light2.transform.position.x + 25.28f+5.64f + min;
                    z3 = light2.transform.position.z;
                }
            }

            //����
            if (speed1 <= maxspeed && !isReduce && !isfollow && !isReduce1)
            {
                speed1 += accelerated_speed * Time.deltaTime;
            }
            //���ٵ�һ��λ��
            if (isReduce && !isfollow)
            {
                Debug.Log("���ٵ�һ�׶�");
                if (l1.walk == 2 && !isfollow)
                {
                    Debug.Log("������ʻ");
                    isReduce1 = false;
                    isReduce = false;
                }
                if (rd.position.x < (x3 + 2.0f) && rd.position.x > x3 - 2.0f && rd.position.z < z3 + 0.2f && rd.position.z > z3 - 0.2f && (Mathf.Abs(rd.transform.forward.z) >0.8f)) 
                {
                    isReduce1 = true;
                }
                if (rd.position.x < (x3 + 0.2f) && rd.position.x > x3 - 0.2f && rd.position.z < z3 +2.0f && rd.position.z > z3 - 2.0f && (Mathf.Abs(rd.transform.forward.x) > 0.8f))
                {
                    isReduce1 = true;
                }
                if (!isReduce1 && speed1 > maxspeed1 + 0.5f)
                {
                    speed1 -= brakespeed * Time.deltaTime;
                }
                if (!isReduce1 && speed1 > maxspeed1 + 0.5f)
                {
                    speed1 += accelerated_speed * Time.deltaTime;
                }
                if (isReduce1)
                {
                    if (speed1 > 0)
                    {
                        speed1 -= brakespeed * Time.deltaTime;
                        if (speed1 < 0)
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
            }

            if (isReduce1)
            {
                Debug.Log("ȫ��ɲ��");
                if (speed1 > 0)
                {
                    speed1 -= brakespeed * Time.deltaTime;
                    if (speed1 < 0)
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
            //����
            if (isfollow && !isReduce && !isReduce1)
            {
                //Debug.Log("����");
                float maxspeed2 = 0.0f;
                if (car.GetComponent<AI_driver>())
                {
                    maxspeed2 = car.GetComponent<AI_driver>().speed1;
                }
                if (car.GetComponent<AI_driver1>())
                {
                    maxspeed2 = car.GetComponent<AI_driver1>().speed1;
                }
                if (car.GetComponent<AI_driver2>())
                {
                    maxspeed2 = car.GetComponent<AI_driver2>().speed1;
                }
                if (car.GetComponent<car1>())
                {
                    maxspeed2 = car.GetComponent<car1>().speed1;
                }
                carspeed = maxspeed2;
                if (speed1 > maxspeed2)
                {
                    speed1 -= brakespeed * Time.deltaTime;
                    if (speed1 < 0)
                    {
                        speed1 = 0.0f;
                    }
                }
                else if (speed1 < maxspeed2)
                {
                    speed1 += accelerated_speed * Time.deltaTime;
                }
            }

            //ת���ж�
            if (rd.position.x < (targetpos1.x + 2.0f) && rd.position.x > targetpos1.x - 2.0f && rd.position.z < targetpos1.y + 0.2f && rd.position.z > targetpos1.y - 0.2f && isMove)
            {
                isRota = true;
                rotation = transform.up * h * speed1;
            }
            if (rd.position.x < (targetpos2.x + 0.2f) && rd.position.x > (targetpos2.x - 0.2f) && rd.position.z < (targetpos2.y + 2.0f) && rd.position.z > (targetpos2.y - 2.0f) && isMove)
            {
                rotation = transform.up * 0.0f;
                forward = new Vector3(1.0f, 0, 0);
                isRota = false;
            }
            if (rd.position.x < (targetpos3.x + 0.2f) && rd.position.x > (targetpos3.x - 0.2f) && rd.position.z < (targetpos3.y + 2.0f) && rd.position.z > (targetpos3.y - 2.0f) && isMove)
            {
                isRota = true;
                rotation = transform.up * h * speed1;
            }
            if (rd.position.x < (targetpos4.x + 2.0f) && rd.position.x > targetpos4.x - 2.0f && rd.position.z < targetpos4.y + 0.2f && rd.position.z > targetpos4.y - 0.2f && isMove)
            {
                rotation = transform.up * 0.0f;
                forward = new Vector3(0, 0, 1.0f);
                isRota = false;
            }
            if (rd.position.x < (targetpos5.x + 2.0f) && rd.position.x > targetpos5.x - 2.0f && rd.position.z < targetpos5.y + 0.2f && rd.position.z > targetpos5.y - 0.2f && isMove)
            {
                isRota = true;
                rotation = transform.up * h * speed1;
            }
            if (rd.position.x < (targetpos6.x + 0.2f) && rd.position.x > (targetpos6.x - 0.2f) && rd.position.z < (targetpos6.y + 2.0f) && rd.position.z > (targetpos6.y - 2.0f) && isMove)
            {
                rotation = transform.up * 0.0f;
                forward = new Vector3(-1.0f, 0, 0);
                isRota = false;
            }
            if (rd.position.x < (targetpos7.x + 0.2f) && rd.position.x > (targetpos7.x - 0.2f) && rd.position.z < (targetpos7.y + 2.0f) && rd.position.z > (targetpos7.y - 2.0f) && isMove)
            {
                isRota = true;
                rotation = transform.up * -h * speed1;
            }
            if (rd.position.x < (targetpos8.x + 2.0f) && rd.position.x > targetpos8.x - 2.0f && rd.position.z < targetpos8.y + 0.2f && rd.position.z > targetpos8.y - 0.2f && isMove)
            {
                rotation = transform.up * 0.0f;
                forward = new Vector3(0, 0, 1.0f);
                isRota = false;
            }
            if (rd.position.x < (targetpos9.x + 2.0f) && rd.position.x > targetpos9.x - 2.0f && rd.position.z < targetpos9.y + 0.2f && rd.position.z > targetpos9.y - 0.2f && isMove)
            {
                isRota = true;
                rotation = transform.up * -h * speed1;
            }
            if (rd.position.x < (targetpos10.x + 0.2f) && rd.position.x > (targetpos10.x - 0.2f) && rd.position.z < (targetpos10.y + 2.0f) && rd.position.z > (targetpos10.y - 2.0f) && isMove)
            {
                rotation = transform.up * 0.0f;
                forward = new Vector3(1.0f, 0, 0);
                isRota = false;
            }
            if (rd.position.x < (targetpos11.x + 0.2f) && rd.position.x > (targetpos11.x - 0.2f) && rd.position.z < (targetpos11.y + 2.0f) && rd.position.z > (targetpos11.y - 2.0f) && isMove)
            {
                isRota = true;
                rotation = transform.up * -h * speed1;
            }
            if (rd.position.x < (targetpos12.x + 2.0f) && rd.position.x > targetpos12.x - 2.0f && rd.position.z < targetpos12.y + 0.2f && rd.position.z > targetpos12.y - 0.2f && isMove)
            {
                rotation = transform.up * 0.0f;
                forward = new Vector3(0, 0, -1.0f);
                isRota = false;
            }

            if (addroadblock)
            {
                Debug.Log("����·��");
                roadblock = GameObject.FindGameObjectsWithTag("roadblock");
                addroadblock = !addroadblock;
            }

            //���¼���·��
            if (removeroadblock)
            {
                Debug.Log("����·��");
                roadblock = GameObject.FindGameObjectsWithTag("roadblock");
                roadblock = GameObject.FindGameObjectsWithTag("roadblock");
                Debug.Log(roadblock.Length);
                isReduce1 = false;
                for (int i = 0; i < roadblock.Length; i++)
                {
                    if (roadblock[i] == null)
                    {
                        continue;
                    }
                    if (rd.position.x > roadblock[i].transform.position.x - (10.0f + 2.0f + 2.5f) && rd.position.z < roadblock[i].transform.position.z + 2.0f && rd.position.z > roadblock[i].transform.position.z - 2.0f && rd.transform.forward.x > 0.9f)
                    {
                        isReduce1 = true;
                    }
                    if (rd.position.x < roadblock[i].transform.position.x + (10.0f + 2.0f + 2.5f) && rd.position.z < roadblock[i].transform.position.z + 2.0f && rd.position.z > roadblock[i].transform.position.z - 2.0f && rd.transform.forward.x < -0.9f)
                    {
                        isReduce1 = true;
                    }
                    if (rd.position.z < roadblock[i].transform.position.z + (10.0f + 2.0f + 2.5f) && rd.position.x < roadblock[i].transform.position.x + 2.0f && rd.position.x > roadblock[i].transform.position.x - 2.0f && rd.transform.forward.z < -0.9f)
                    {
                        isReduce1 = true;
                    }
                    if (rd.position.z > roadblock[i].transform.position.z - (10.0f + 2.0f + 2.5f) && rd.position.x < roadblock[i].transform.position.x + 2.0f && rd.position.x > roadblock[i].transform.position.x - 2.0f && rd.transform.forward.z > 0.9f)
                    {
                        isReduce1 = true;
                    }
                }
                removeroadblock = !removeroadblock;
            }
            //��������
            if (speed1 > 0)
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
            if (!isRota)
                rd.transform.forward = forward;
            rd.velocity = speed;
            rd.angularVelocity = rotation;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // ��ײ�ܱ�Ϊ0
        speed1 = 0;
        if (!collision.gameObject.name.Equals("ground"))
            database.GetComponent<database>().coli(2);
        Debug.Log("��ײ");
    }
}
