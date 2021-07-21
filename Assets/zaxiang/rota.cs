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
        // Quaternion.Slerp()第二个参数需要的是四元数,所以这里需要将目标的角度转成四元数去计算
        targetAngels = Quaternion.Euler(0, 90f, 0);
    }
    // Update is called once per frame
    void Update()
    {
        //  用 slerp 进行插值平滑的旋转
        transform.rotation = Quaternion.Slerp(transform.rotation, targetAngels, rotateSpeed * Time.deltaTime);
        // 当初始角度跟目标角度小于1,将目标角度赋值给初始角度,让旋转角度是我们需要的角度
        if (Quaternion.Angle(targetAngels, transform.rotation) < 1)
        {
            transform.rotation = targetAngels;
        }
    }
}