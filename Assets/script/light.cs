using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    public GameObject red;
    public GameObject yellow;
    public GameObject green;
    public int walk ;//0Îªºì£¬2ÎªÂÌ
    public float redtime;
    public float greentime;
    public float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        red.SetActive(false);
        green.SetActive(false);
        yellow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(walk == 0)
        {
            red.SetActive(true);
            time += Time.deltaTime;
            if (time >= redtime)
            {
                walk++;
                red.SetActive(false);
                time = 0.0f;
            }
        }else if(walk == 2)
        {
            green.SetActive(true);
            time += Time.deltaTime;
            if (time >= greentime)
            {
                walk++;
                green.SetActive(false);
                time = 0.0f;
            }
        }
        else
        {
            time = time + Time.deltaTime;
            yellow.SetActive(true);
            if (time > 3.0f)
            {
                walk++;
                yellow.SetActive(false) ;
                if (walk == 4)
                {
                    walk = 0;
                }
                time = 0.0f;
            }
        }
    }
}
