using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateThis : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed = 2f;
    Quaternion targetAngels;
    private void Start()
    {
        // Quaternion.Slerp()�ڶ���������Ҫ������Ԫ��,����������Ҫ��Ŀ��ĽǶ�ת����Ԫ��ȥ����
        targetAngels = Quaternion.Euler(0, 90f, 0);
    }
    // Update is called once per frame
    void Update()
    {
        //  �� slerp ���в�ֵƽ������ת
        transform.rotation = Quaternion.Slerp(transform.rotation, targetAngels, rotateSpeed * Time.deltaTime);
        // ����ʼ�Ƕȸ�Ŀ��Ƕ�С��1,��Ŀ��Ƕȸ�ֵ����ʼ�Ƕ�,����ת�Ƕ���������Ҫ�ĽǶ�
        if (Quaternion.Angle(targetAngels, transform.rotation) < 1)
        {
            transform.rotation = targetAngels;
        }
    }
}