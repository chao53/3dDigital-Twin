using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class database : MonoBehaviour
{
    public GameObject carDriver;
    public GameObject Camera;
    public GameObject Camera2;
    public Text statisticsText;
    private int dirverRes = 0;
    private int aiRes = 0;

    // Start is called before the first frame update
    bool isab = true;
    void Start()
    {
        Camera.SetActive(true);
        Camera.GetComponent<god>().enabled = false;
        carDriver.GetComponent<car1>().enabled = false;
        Camera2.SetActive(false);
        dirverRes = 0;
        aiRes = 0;
        statisticsText.text = " ";
    }


    public void coli(int i)
    {
        if(i == 1)
        {
            dirverRes++;
        }else
        {
            aiRes++;
        }
        statisticsText.text = "总碰撞次数" + (dirverRes + aiRes) + "\n人为原因造成碰撞次数："+dirverRes+"\nai原因造成碰撞次数"+aiRes;
    }



    public void isGod()
    {
        Camera.SetActive(true);
        Camera.GetComponent<god>().enabled = true;
        carDriver.GetComponent<car1>().enabled = false;
        Camera2.SetActive(false);
    }

    public void isDriver()
    {
        Camera2.SetActive(true);
        Camera.SetActive(false);
        Camera.GetComponent<god>().enabled = false;
        carDriver.GetComponent<car1>().enabled = true;
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
